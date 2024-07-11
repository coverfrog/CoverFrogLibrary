using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cf.CfInputs.Pc
{
    [CreateAssetMenu(menuName = "Cf/Input/Pc", fileName = "Input Pc")]
    public class CfInputPc : CfInput
    {
        private InputState _state;
        
        public override InputState State
        {
            get => _state;
            protected set
            {
                var prevState = _state;
                var nextState = value;
                
                _state = nextState;
            }
        }

        public override void InputUpdate(CfInputManager cfInputManager)
        {
            
        }
    }
}
