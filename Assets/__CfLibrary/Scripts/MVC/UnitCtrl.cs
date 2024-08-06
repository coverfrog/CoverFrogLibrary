using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    // Ctrl Model, View
    public abstract class UnitCtrl<TView, TModel> : MonoBehaviour where TView : UnitView where TModel : UnitModel
    {
        #region > Text
        [Header("[ Text ]")]
        [SerializeField] protected string codeName;
        [SerializeField] protected string displayName;
        [SerializeField, TextArea] protected string description;
        
        public string CodeName => codeName;
        public string DisplayName => displayName;
        public string Description => description;
        #endregion

        #region > Mvc
        [Header("[ Mvc ]")] 
        [SerializeField] protected TView view;
        [SerializeField] protected TModel model;
        #endregion
    }
}
