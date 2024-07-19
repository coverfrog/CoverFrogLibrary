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
        private InputModule _module;


        //
        
        
        
        //
        
        private void Awake()
        {
            _ = Module;
        }

        private void Update()
        {
            Module.InputUpdate<T>();
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
