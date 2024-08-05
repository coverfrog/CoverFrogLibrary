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
        [Header("[ Ctrl ]")]
        [SerializeField] private PlayerMove playerMove;
        [SerializeField] private PlayerAnimator playerAnimator;
        
        private void OnEnable()
        {
            CameraFollowFirstPerson.SetTarget(this, transform);
        }

        private void Update()
        {
            playerAnimator.SetBool(PlayerAnimKey.IsMove, playerMove.IsMove);
        }
    }
}
