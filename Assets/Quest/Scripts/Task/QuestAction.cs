using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    public abstract class QuestAction : ScriptableObject
    {
        // step 1 : basic count define
        // action's owner is task
        public abstract int Run(QuestTask task, int currentSuccessCount, int successCount);
    }
}
