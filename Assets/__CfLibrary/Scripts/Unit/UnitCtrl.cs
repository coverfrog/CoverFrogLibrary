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
        
        #region > Option
        [Header("[ Option ]")]
        [SerializeField] protected bool isCanControl;

        public bool IsCanControl => isCanControl;
        
        #endregion
        
        #region > State
        [Header("[ State ]")]
        [SerializeField] protected T currentState;

        protected void ChangeState(Object sender, T nextState)
        {
            var prevState = currentState;
            currentState = nextState;

            ChangeStated(sender, prevState, nextState);
        }

        protected abstract void ChangeStated(Object sender, T prevState, T nextState);
        #endregion
    }
}
