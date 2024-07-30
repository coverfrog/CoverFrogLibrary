using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public enum PlayerState
    {
        InActive,
        Idle,
    }

    public class PlayerCtrl : UnitCtrl<PlayerState>
    {
        private void OnEnable()
        {
            CameraFollow.SetTarget(this, transform);
        }
    }
}
