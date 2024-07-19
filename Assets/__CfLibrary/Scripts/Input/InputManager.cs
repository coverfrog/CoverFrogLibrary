using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public abstract class InputManager<T> : Singleton<InputManager<T>> where T : Enum
    {
        private Dictionary<T, InputCode> _inputCodeDictionary;
        private InputModule _module;

        public override void Awake()
        {
            base.Awake();
            _ = Module;
        }
        
        //

        public void TryAdd(T t, InputCode inputCode)
        {
            if (_inputCodeDictionary.TryAdd(t, inputCode))
            {
                
            }
        }

        //

        private InputModule Module => 
            _module ??= InitModule();
        
        private InputModule InitModule() 
        {
            var envName = Application.platform.ToString();

            if (AnyString(envName, "WindowsEditor", "WindowsPlayer"))
                return _module = gameObject.AddComponent<InputPc>();

            return null;
        }
        
        //

        private static bool AnyString(string envName, params string[] names) => names.Any(x => x == envName);
    }
}
