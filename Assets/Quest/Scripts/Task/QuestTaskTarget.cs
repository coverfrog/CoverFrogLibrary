using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.QuestSys
{
    public abstract class QuestTaskTarget : ScriptableObject
    {
        public abstract object Value { get; }
        
        public abstract bool IsEqual(object target);
    }
}
