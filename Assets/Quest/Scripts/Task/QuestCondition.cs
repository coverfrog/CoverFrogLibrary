using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    public abstract class QuestCondition : ScriptableObject
    {
        [Header("[ Text ]")]
        [SerializeField] private string codeName;
        [SerializeField, TextArea] private string description;

        public string CodeName => codeName;
        public string Description => description;

        public abstract bool IsPass(Quest quest);
    }
}
