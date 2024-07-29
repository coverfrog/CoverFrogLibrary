using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace CoverFrog
{
    public abstract class AudioManager<T> : Singleton<AudioManager<T>> where T : Enum
    {
        [Header("[ Audio Db ]")]
        [SerializeField] private AudioDatabase database;


        #region > Get
        
        private AudioSource GetSource(T audioType) => AudioDictionary[audioType.ToString()];

        private AudioClip GetClip(string clipName) => database.AudioClipList.FirstOrDefault(x => x.name == clipName);
        
        #endregion

        #region > Method

        public override void Awake()
        {
            base.Awake();
            _ = AudioDictionary;
        }

        public void Play(Object sender, T audioType, string audioName)
        {
            var source = GetSource(audioType);
            var clip = GetClip(audioName);

            source.clip = clip;
            source.Play();
        }

        #endregion

        #region > Dictionary
        
        private Dictionary<string, AudioSource> _audioDictionary;

        private Dictionary<string, AudioSource> AudioDictionary =>
            _audioDictionary ??= DictionaryInit();
        
        private Dictionary<string, AudioSource> DictionaryInit()
        {
            var audioDictionary = new Dictionary<string, AudioSource>();
            var enumNameArray = Enum.GetNames(typeof(T));

            foreach (var enumName in enumNameArray)
            {
                CreateNewSource(enumName, out var newSource);
                if (audioDictionary.TryAdd(enumName, newSource))
                {
                    
                }
            }

            return audioDictionary;
        }

        private void CreateNewSource(string enumName, out AudioSource newSource)
        {
            var obj = new GameObject(enumName);
            obj.transform.SetParent(transform);

            newSource = obj.AddComponent<AudioSource>();
        }
        
        #endregion
    }
}

