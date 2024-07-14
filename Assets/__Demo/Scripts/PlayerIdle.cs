using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverFrog.Fsm;

namespace CoverFrog
{
    public class PlayerIdle : MonoBehaviour, IFsmState<PlayerController>
    {
        public PlayerController Controller { get; set; }
        
        public void Handle(PlayerController newController)
        {
            Controller = newController;
        }
    }
}
