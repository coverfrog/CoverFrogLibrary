using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoverFrog
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                // exist : return
                if (_instance != null)
                    return _instance;

                // find
                _instance = FindObjectOfType<T>();

                // exist : return
                if (_instance != null)
                    return _instance;

                // create new
                var obj = new GameObject
                {
                    name = typeof(T).Name
                };

                _instance = obj.AddComponent<T>();

                // return 
                return _instance;
            }
        }

        public virtual void Awake()
        {
            if (_instance == null)
            {
                // null -> instance
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                // exist => destroy
                Destroy(gameObject);
            }
        }
    }
}