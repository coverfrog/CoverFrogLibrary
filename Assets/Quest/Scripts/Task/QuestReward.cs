using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    public abstract class QuestReward : ScriptableObject
    {
        [Header("[ Text ]")]
        [SerializeField] private string codeName;
        [SerializeField] private string displayName;
        [SerializeField, TextArea] private string description;

        [Header("[ Resources ]")] 
        [SerializeField] private Sprite icon;

        [Header("[ Option ]")] 
        [SerializeField] private int quantity;
        
        public string CodeName => codeName;
        public string DisPlayName => displayName;
        public string Description => description;
        
        public Sprite Icon => icon;
        
        public int Quantity => quantity;

        public abstract void Give(Quest quest);

    }
}
