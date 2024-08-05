using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public class CameraFollowFirstPerson : MonoBehaviour
    {
        [Header("[ Option ]")] 
        [SerializeField] private float height = 20;
        [SerializeField] private float distance = 20;
        
        [Header("[ Cam ]")]
        [SerializeField] private Camera cam;

        private static Transform _target;

        public static void SetTarget(Object sender, Transform target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            
        }
    }
}
