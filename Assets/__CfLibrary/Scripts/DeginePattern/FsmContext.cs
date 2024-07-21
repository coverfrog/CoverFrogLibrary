using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    public class FsmContext<T> where T : Behaviour
    {
        public IFsmState<T> CurrentState { get; set; }

        private readonly T _ctrl;

        public FsmContext(T ctrl)
        {
            _ctrl = ctrl;
        }

        public void Transition()
        {
            CurrentState.Handle(_ctrl);
        }
        
        public void Transition(IFsmState<T> fsmState)
        {
            CurrentState = fsmState;
            CurrentState.Handle(_ctrl);
        }
    }
}
