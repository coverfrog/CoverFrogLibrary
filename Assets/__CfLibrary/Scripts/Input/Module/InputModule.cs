using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    public abstract class InputModule : MonoBehaviour
    {
        public abstract void InputUpdate<T>() where T : Enum;
    }
}
