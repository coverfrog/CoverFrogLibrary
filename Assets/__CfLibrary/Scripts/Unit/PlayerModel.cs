using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    // Data, Logic
    [Serializable]
    public class PlayerModel : UnitModel
    {
        [SerializeField] private int moveSpeedMax;
        [SerializeField] private Vector3 position;
        [SerializeField] private Quaternion rotation;

        public Vector3 Position => position;

        public Quaternion Rotation => rotation;

        public void Init(Vector3 initPosition)
        {
            position = initPosition;
        }

        public void Move(Vector3 direction)
        {
            position += direction * (moveSpeedMax * Time.deltaTime);
        }

        public void Rotate(Vector3 direction)
        {
            rotation = Quaternion.LookRotation(direction);
        }
    }
}
