using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CfInputs
{
    public enum InputState
    {
        InActive,
        Down,
        Up,
        Holding,
    }

    public enum InputEvent
    {
        None,
        Move,
    }

    public abstract class CfInput : ScriptableObject
    {
        public abstract InputState State { get; protected set; }
     
        public abstract void InputUpdate(CfInputManager cfInput);
    }
}
