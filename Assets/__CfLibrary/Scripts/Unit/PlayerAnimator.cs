using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CoverFrog
{
    public enum PlayerAnimKey
    {
        IsMove,
    }

    public class PlayerAnimator : SerializedMonoBehaviour
    {
        [SerializeField] private Animator animator;

        public void SetBool(PlayerAnimKey animKey, bool value)
        {
            animator.SetBool(animKey.ToString(), value);
        }
    }
}
