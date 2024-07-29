using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public abstract class UnitCtrl<T> : MonoBehaviour where T : Enum
    {
        #region > Text
        [Header("[ Text ]")]
        [SerializeField] private string codeName;
        [SerializeField, TextArea] private string description;

        public string CodeName => codeName;
        public string Description => description;
        
        #endregion
        
        #region > State
        [Header("[ State ]")]
        [SerializeField] protected T currentState;
        #endregion
    }
}
