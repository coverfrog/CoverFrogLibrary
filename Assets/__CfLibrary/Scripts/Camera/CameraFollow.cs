using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public abstract class CameraFollow : CameraCtrl
    {
        protected abstract Camera FollowCam { get; }

        protected static Transform Target;

        public static void SetTarget(Object sender, Transform target)
        {
            Target = target;
        }

        protected abstract void Follow();

        public void Update()
        {
            Follow();
        }
    }
}
