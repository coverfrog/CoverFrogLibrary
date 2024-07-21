using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    public interface IFsmState<T> where T : class
    {
        public T Owner { get; set; }
        
        public void Handle(T owner);
    }
}
