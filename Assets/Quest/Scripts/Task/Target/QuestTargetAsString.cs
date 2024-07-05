using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    
    [CreateAssetMenu(menuName = "CoverFrog/Quest/Target/String", fileName = "StringTarget")]
    public class QuestTargetAsString : QuestTaskTarget
    {
        [SerializeField] private string value;

        public override object Value => value;
        
        public override bool IsEqual(object target)
        {
            var targetAsString= target as string;

            if (targetAsString == null)
            {
                return false;
            }

            return value == targetAsString;
        }
    }
}
