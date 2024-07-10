using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMove move;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var dir = move.InputUpdate();
            if (dir.HasValue)
            {
                move.To(this, dir.Value);
            }
        }
    }
}
