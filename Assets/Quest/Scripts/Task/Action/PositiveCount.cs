using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    [CreateAssetMenu(menuName = "CoverFrog/Quest/QuestAction/PositiveCount", fileName = "PositiveCount")]
    public class PositiveCount : QuestAction
    {
        public override int Run(QuestTask task, int currentSuccessCount, int successCount)
        {
            return successCount > 0 ? currentSuccessCount + successCount : currentSuccessCount;
        }
    }
}
