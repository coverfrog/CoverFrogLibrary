using System;
using System.Collections;
using System.Collections.Generic;
using CoverFrog;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Bird
{
    public enum PlayerState
    {
        InActive,
        Setup,
        Idle,
        Move,
    }

    public class PlayerCtrl : UnitCtrl<PlayerState>
    {
        #region > Unity 
        private void Awake()
        {
            ChangeState(this, PlayerState.Setup);
        }
        #endregion

        protected override void ChangeStated(Object sender, PlayerState prevState, PlayerState nextState)
        {
            
        }
    }
}
