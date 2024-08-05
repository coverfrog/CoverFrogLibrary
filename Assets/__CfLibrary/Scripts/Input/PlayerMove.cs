using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    
    public class InputMove : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 3.0f;
        [SerializeField] private float rotSpeeed = 10.0f;
        [SerializeField] private bool isCanMove = true;
        
        private Vector3 _moveDir;
        
        private void OnEnable()
        {
            InputCtrl.OnMoveStarted += OnMoveStarted;
            InputCtrl.OnMove += OnMove;
            InputCtrl.OnMoveCanceled += OnMoveCanceled;
        }

        private void OnDisable()
        {
            InputCtrl.OnMoveStarted -= OnMoveStarted;
            InputCtrl.OnMove -= OnMove;
            InputCtrl.OnMoveCanceled -= OnMoveCanceled;
        }

        private void Update()
        {
            if (!isCanMove) return;

            if (!IsMove) return;
            
            transform.position += _moveDir * ( Time.deltaTime * moveSpeed );
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_moveDir), rotSpeeed * Time.deltaTime) ;
        }
        
        public bool IsMove => _moveDir.magnitude > 0;
        
        private void OnMoveStarted(Vector3 value)
        {
            _moveDir = value;
        }

        private void OnMove(Vector3 value)
        {
            _moveDir = value;
        }

        private void OnMoveCanceled(Vector3 value)
        {
            _moveDir = Vector3.zero;
        }
    }
}
