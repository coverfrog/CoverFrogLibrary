using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    [CreateAssetMenu(menuName = "CoverFrog/Quest/QuestAction/NegativeCount", fileName = "NegativeCount")]
    public class NegativeCount : QuestAction
    {
        public override int Run(QuestTask task, int currentSuccessCount, int successCount)
        {
            return successCount < 0 ? currentSuccessCount - successCount : currentSuccessCount;
        }
    }
}
