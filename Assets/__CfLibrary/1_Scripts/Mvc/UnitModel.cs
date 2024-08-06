using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    // Data, Logic
    public abstract class UnitModel : ScriptableObject
    {
        public static T Clone<T>(T original) where T : UnitModel
        {
            return Instantiate(original);
        }
    }
}
