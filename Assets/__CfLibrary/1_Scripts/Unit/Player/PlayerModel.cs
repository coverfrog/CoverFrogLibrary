using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    // Data, Logic
    [CreateAssetMenu(menuName = "CoverFrog/Model", fileName = "Model")]
    public class PlayerModel : UnitModel
    {
        [SerializeField] private float moveSpeedMax = 3.0f;

        public float MoveSpeedMax => moveSpeedMax;
    }
}
