using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    // Ctrl Model, View
    [RequireComponent(typeof(PlayerView))]
    public class PlayerCtrl : UnitCtrl<PlayerView, PlayerModel>
    {
        private void Start()
        {
            model.Init(transform.position);
            
            view.OnMoveInput += MoveInput;
        }

        private void MoveInput(Vector3 direction)
        {
            model.Move(direction);
            model.Rotate(direction);
            
            UpdateView();
        }

        private void UpdateView()
        {
            view.UpdateRotation(model.Rotation);
            view.UpdatePosition(model.Position);
        }
    }
}
