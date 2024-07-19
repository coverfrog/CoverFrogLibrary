using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Bird
{
    public enum PlayerState
    {
        Idle,
        Move,
    }

    public class PlayerCtrl : CoverFrog.UnitCtrl<PlayerState>
    {
        protected override void ChangeStated(Object sender, PlayerState prevState, PlayerState nextState)
        {
            
        }
    }
}
