using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverFrog.Fsm;

namespace CoverFrog
{
    public class PlayerController : MonoBehaviour
    {
        private FsmStateContext<PlayerController> context;
        private IFsmState<PlayerController> iIdle, iMove;
        
        private void Awake()
        {
            context = new FsmStateContext<PlayerController>(this);

            iIdle ??= gameObject.AddComponent<PlayerIdle>();
            iMove ??= gameObject.AddComponent<PlayerMove>();
        }
    }
}
