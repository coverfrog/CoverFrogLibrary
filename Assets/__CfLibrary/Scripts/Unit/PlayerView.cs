using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    // Display, Input
    public class PlayerView : UnitView
    {
        public delegate void MoveInputHandler(Vector3 direction);

        public event MoveInputHandler OnMoveInput;

        private void Update()
        {
            var h = Input.GetAxis($"Horizontal");
            var v = Input.GetAxis($"Vertical");
            var d = (Vector3.right * h + Vector3.forward * v).normalized;
            
            if (d.magnitude > 0)
            {
                OnMoveInput?.Invoke(d);
            }
        }
        
        public void UpdateRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
        
        public void UpdatePosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}
