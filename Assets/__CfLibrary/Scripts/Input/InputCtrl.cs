using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CoverFrog
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputCtrl : MonoBehaviour
    {
        public static Action<Vector3> 
            OnMove, 
            OnMoveStarted, 
            OnMoveCanceled;

        private InputAction _moveAction;

        private void Awake()
        {
            var inputActions = GetComponent<PlayerInput>().actions;

            _moveAction = inputActions.FindAction("Move", throwIfNotFound: true);
            _moveAction.started += ReceiveMove;
            _moveAction.performed += ReceiveMove;
            _moveAction.canceled += ReceiveMove;
        }

        private static void ReceiveMove(InputAction.CallbackContext callbackContext)
        {
            var value = callbackContext.ReadValue<Vector2>();
            var valueAsVector3 = new Vector3(value.x, 0, value.y);

            if (callbackContext.started)
            {
                OnMoveStarted?.Invoke(valueAsVector3);
            }

            else if(callbackContext.performed)
            {
                OnMove?.Invoke(valueAsVector3);
            }

            else if(callbackContext.canceled)
            {
                OnMoveCanceled?.Invoke(valueAsVector3);
            }
        }
    }
}
