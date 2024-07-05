using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoverFrog.QuestSys
{
    public enum QuestTaskGroupState
    {
        InActive,
        Running,
        Complete,
    }

    [Serializable]
    public class QuestTaskGroup
    {
        [SerializeField] private List<QuestTask> tasks;

        public IReadOnlyList<QuestTask> Tasks => tasks;
        
        public Quest Owner { get; private set; }

        public bool IsAllTaskComplete => tasks.All(x => x.IsComplete);
        
        public QuestTaskGroupState State { get; private set; }

        public void Setup(Quest owner)
        {
            Owner = owner;
            tasks.ForEach(x => x.SetUp(owner));
        }

        public void Start()
        {
            State = QuestTaskGroupState.Running;
            tasks.ForEach(x => x.Start());
        }

        public void End()
        {
            State = QuestTaskGroupState.Complete;
            tasks.ForEach(x => x.End());
        }

        public void ReceiveReport(string category, object target, int successCount)
        {
            foreach (var task in tasks)
            {
                if (task.IsTarget(category, target))
                {
                    task.ReceiveReport(successCount);
                }
            }
        }

        public bool IsComplete => State == QuestTaskGroupState.Complete;

        public void Complete()
        {
            if(IsComplete)
                return;

            State = QuestTaskGroupState.Complete;

            foreach (var task in tasks)
            {
                if (!task.IsComplete)
                {
                    task.Complete();
                }
            }
        }
    }
}
