using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.Fsm
{
    public class FsmStateContext<T> where T : Behaviour
    {
        private IFsmState<T> currentState;

        public IFsmState<T> CurrentState
        {
            get => currentState;
            set
            {
                var prevState = currentState;

                currentState = value;
            }
        }

        private readonly T controller;

        public FsmStateContext(T newController)
        {
            controller = newController;
        }

        public void Transition()
        {
            currentState.Handle(controller);
        }

        public void Transition(IFsmState<T> newState)
        {
            currentState = newState;
            currentState.Handle(controller);
        }
    }
}
