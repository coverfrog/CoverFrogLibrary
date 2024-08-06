using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    // Data, Logic
    [Serializable]
    public class UnitModel
    {
        [SerializeField] private int moveSpeedMax;

        public void Init(int moveSpeedMax)
        {
            this.moveSpeedMax = moveSpeedMax;
        }

        public void PowerView()
        {
            
        }
    }
}
