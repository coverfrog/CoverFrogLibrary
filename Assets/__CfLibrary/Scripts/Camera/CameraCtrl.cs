using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    public class CameraCtrl : MonoBehaviour
    {
        private Camera _cam;

        private void Awake()
        {
            _cam = transform.GetChild(0).GetComponent<Camera>();
        }
    }
}
