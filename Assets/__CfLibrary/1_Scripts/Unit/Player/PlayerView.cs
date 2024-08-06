using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CoverFrog
{
    // Display, Input
    public class PlayerView : UnitView
    {
        private void OnEnable()
        {
            InputOverlay.OnMouseDown += SetMoveTargetPoint;
        }

        private void OnDisable()
        {
            InputOverlay.OnMouseDown -= SetMoveTargetPoint;
        }

        private void SetMoveTargetPoint(PointerEventData eventData)
        {
            
        }
    }
}
