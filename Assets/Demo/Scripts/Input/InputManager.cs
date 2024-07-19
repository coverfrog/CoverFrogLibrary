using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverFrog;

namespace Bird
{
    public enum InputEvent
    {
        MoveLeft,
        MoveRight,
        MoveForward,
        MoveBack,
        MoveToPoint,
    }

    public class InputManager : InputManager<InputEvent>
    {
        
    }
}
