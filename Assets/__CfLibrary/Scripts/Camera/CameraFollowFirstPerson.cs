using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CoverFrog
{
    public class CameraFollowFirstPerson : CameraFollow
    {
        [Header("[ Option ]")] 
        [SerializeField] private float height = 20;
        [SerializeField] private float distance = 20;
        
        private Camera _followCam;

        protected override Camera FollowCam =>
            _followCam ??= transform.GetChild(0).GetComponent<Camera>();

        protected override void Follow()
        {
            if(!Target)
                return;

            transform.position =
                Target.position +
                Vector3.down * distance +
                Vector3.up * height;
        }
    }
}
