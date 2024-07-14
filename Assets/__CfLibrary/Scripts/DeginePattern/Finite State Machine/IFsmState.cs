using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog.Fsm
{
    public interface IFsmState<T> where T : Behaviour
    {
        public T Controller { get; set; }
        
        void Handle(T newController);
    }
}
