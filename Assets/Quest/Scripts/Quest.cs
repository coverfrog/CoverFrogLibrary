using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoverFrog.QuestSys
{
    public enum QuestState
    {
        InActive,
        Running,
        Complete,
        Cancel,
        WaitingForCompletion,
    }

    [CreateAssetMenu(menuName = "CoverFrog/Quest/Quest", fileName = "Quest")]
    public class Quest : ScriptableObject
    {
        [Header("[ Text ]")]
        [SerializeField] private string codeName;
        [SerializeField] private string displayName;
        [SerializeField, TextArea] private string description;
       
        [Header("[ Info ]")] 
        [SerializeField] private QuestCategory category;
        [SerializeField] private Sprite icon;

        [Header("[ Setting ]")]
        [SerializeField] private bool isAutoComplete;
        [SerializeField] private bool isCancelAble;

        [Header("[ Tasks ]")] 
        [SerializeField] private List<QuestTaskGroup> taskGroups;

        [Header("[ Rewards ]")] 
        [SerializeField] private List<QuestReward> rewards;

        [Header("[ Condition ]")] 
        [SerializeField] private List<QuestCondition> acceptConditions;
        [SerializeField] private List<QuestCondition> cancelConditions;
        
        private int currentTaskGroupIndex;
        
        private QuestState state;

        public delegate void TaskSuccessChangeHandler(Quest quest, QuestTask task, int currentSuccess, int prevSuccess);
        public delegate void CompleteHandler(Quest quest);
        public delegate void CancelHandler(Quest quest);
        public delegate void NewTaskGroupHandler(Quest quest, QuestTaskGroup current, QuestTaskGroup prev);

        public event TaskSuccessChangeHandler OnTaskSuccessChange;
        public event CompleteHandler OnComplete;
        public event CancelHandler OnCancel;
        public event NewTaskGroupHandler OnNewTaskGroup;
        
        public string CodeName => codeName;
        public string DisplayName => displayName;
        public string Description => description;
        public QuestCategory Category => category;
        public Sprite Icon => icon;

        public QuestState State
        {
            get => state;
            set
            {
                state = value;
            }
        }

        // 지금 현재 납득이 안가는건 
        // 왜 퀘스트에도 category가 있고 quest task 하위에도 category가 있는가?
        public QuestTaskGroup CurrentTaskGroup => taskGroups[currentTaskGroupIndex];

        public IReadOnlyList<QuestTaskGroup> TaskGroups => taskGroups;

        public bool IsRegistered => State != QuestState.InActive;

        public bool IsCompleteAble => State == QuestState.WaitingForCompletion;

        public bool IsComplete => State == QuestState.Complete;

        public bool IsCancel => State == QuestState.Cancel;

        public void OnRegister()
        {
            Debug.Assert(!IsRegistered, "This quest has already been register");

            foreach (var group in taskGroups)
            {
                group.Setup(this);

                foreach (var task in group.Tasks)
                {
                    task.OnSuccess += TaskOnOnSuccess;
                }
            }
        }

        private void TaskOnOnSuccess(QuestTask task, int current, int prev)
        {
            OnTaskSuccessChange?.Invoke(this, task, current, prev);
        }

        public void ReceiveReport(string rCategory, object target, int successCount)
        {
            Debug.Assert(IsRegistered, "This quest has already been register.");
            Debug.Assert(!IsCancel, "This quest been canceled.");

            if(IsComplete)
                return;

            // 여기 구간도 좀 이해안감
            CurrentTaskGroup.ReceiveReport(rCategory, target, successCount);
            
            if (CurrentTaskGroup.IsAllTaskComplete)
            {
                if (currentTaskGroupIndex + 1 == taskGroups.Count)
                {
                    State = QuestState.WaitingForCompletion;
                    if (isAutoComplete)
                    {
                        Complete();
                    }
                }

                else
                {
                    var prevGroup = taskGroups[currentTaskGroupIndex++];
                    prevGroup.End();
                    CurrentTaskGroup.Start();
                    OnNewTaskGroup?.Invoke(this, CurrentTaskGroup, prevGroup);
                }
            }

            else
            {
                State = QuestState.Running;
            }
        }

        
        public void Complete()
        {
            Debug.Assert(IsRegistered, "This quest has already been register.");
            Debug.Assert(!IsCancel, "This quest been canceled.");
            Debug.Assert(!IsCompleteAble, "This quest has already been completed.");
            
            taskGroups.ForEach(x => x.Complete());

            State = QuestState.Complete;

            rewards.ForEach(x => x.Give(this));
            
            OnComplete?.Invoke(this);

            OnTaskSuccessChange = null;
            OnComplete = null;
            OnCancel = null;
            OnNewTaskGroup = null;
        }

        
                
        public void Cancel()
        {
            Debug.Assert(IsRegistered, "This quest has already been register.");
            Debug.Assert(!IsCancel, "This quest been canceled.");
            Debug.Assert(!IsCompleteAble, "This quest has already been completed.");

            State = QuestState.Cancel;
            
            OnCancel?.Invoke(this);
        }

        public IReadOnlyList<QuestReward> Rewards => rewards;

        public virtual bool IsCancelAble => isCancelAble && cancelConditions.All(x => x.IsPass(this));

        public bool IsAcceptAble => acceptConditions.All(x => x.IsPass(this));
    }
}
