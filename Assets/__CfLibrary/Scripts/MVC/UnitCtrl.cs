using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    // Ctrl Model, View
    public abstract class UnitCtrl : MonoBehaviour
    {
        #region > Text
        [Header("[ Text ]")]
        [SerializeField] private string codeName;
        [SerializeField] private string displayName;
        [SerializeField, TextArea] private string description;
        
        public string CodeName => codeName;
        public string DisplayName => displayName;
        public string Description => description;
        #endregion

        #region > Mvc
        [Header("[ Mvc ]")] 
        [SerializeField] private UnitView view;
        [SerializeField] private UnitModel model;
        #endregion

        #region > Unity
        private void Start()
        {
            
        }
        #endregion
    }
}
