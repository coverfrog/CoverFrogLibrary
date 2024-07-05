using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    [CreateAssetMenu(menuName = "CoverFrog/Quest/Condition/TrueCondition", fileName = "TrueCondition")]
    public class TrueCondition : QuestCondition
    {
        public override bool IsPass(Quest quest)
        {
            return true;
        }
    }
}
