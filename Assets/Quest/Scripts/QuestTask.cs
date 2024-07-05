using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoverFrog.QuestSys
{
    public enum QuestTaskState
    {
        InActive,
        Running,
        Complete,
    }

    [CreateAssetMenu(menuName = "CoverFrog/Quest/QuestTask", fileName = "QuestTask")]
    public class QuestTask : ScriptableObject
    {
        [Header("[ Text ]")]
        [SerializeField] private string codeName;
        [SerializeField] private string description;

        [Header("[ Setting ]")] 
        [SerializeField] private int needSuccessToComplete;
        [SerializeField] private bool canReceiveReportDuringCompletion;
    
        private int currentSuccess;
        
        [Header("[ Action ]")]
        [SerializeField] private QuestAction action;

        [Header("[ Target ]")]
        [SerializeField] private QuestTaskTarget[] targets;

        [Header("[ CateGory ]")] 
        [SerializeField] private QuestCategory category;

        private QuestTaskState state;

        
        public string CodeName => codeName;

        public string Description => description;

        public int CurrentSuccess
        {
            get => currentSuccess;
            set
            {
                var prevSuccess = currentSuccess;
                
                currentSuccess = Mathf.Clamp(value, 0, needSuccessToComplete);

                if (currentSuccess != prevSuccess)
                {
                    var nextState = currentSuccess == needSuccessToComplete
                        ? QuestTaskState.Complete
                        : QuestTaskState.Running;

                    state = nextState;
                    
                    OnSuccess?.Invoke(this, currentSuccess, prevSuccess);
                }
            }
        }

        public void ReceiveReport(int successCount)
        {
            CurrentSuccess = action.Run(this, currentSuccess, successCount);
        }

        public bool IsTarget(string category, object target)
        {
            return targets.Any(x => x.IsEqual(target)) &&
                   (!IsComplete || (IsComplete && canReceiveReportDuringCompletion)) &&
                   this.category == category;
        }
        
        public delegate void StateChangeHandler(QuestTask task, QuestTaskState current, QuestTaskState prev);
        
        public delegate void SuccessChangeHandler(QuestTask task, int current, int prev);

        public event StateChangeHandler OnStateChanged;

        public event SuccessChangeHandler OnSuccess;
        
        public QuestTaskState State
        {
            get => state;
            set
            {
                var prev = state;
                state = value;
                OnStateChanged?.Invoke(this, state, prev);
            }
        }

        public bool IsComplete => State == QuestTaskState.Complete;
        
        public Quest Owner { get; private set; }

        public void SetUp(Quest owner)
        {
            Owner = owner;
        }

        public void Start()
        {
            State = QuestTaskState.Running;
        }

        public void End()
        {
            OnStateChanged = null;
            OnSuccess = null;
        }

        public void Complete()
        {
            CurrentSuccess = needSuccessToComplete;
        }

        // 여기에서 category로 넘어가는 과정에 대한 논리적 사고가 이해가 가지 앟음
        // 정확히는 현재 category에 대한 정보를 받아오는건 taskgroup에서 진행되고 있음
    }
}
