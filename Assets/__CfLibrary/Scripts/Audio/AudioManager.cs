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
        [SerializeField] private List<AudioDatabase> audioDatabaseList;

        #region > Get
        private AudioSource GetSource(T audioType) => AudioDictionary[audioType.ToString()];

        private AudioClip GetClip(string clipName)
        {
            foreach (var audioDatabase in audioDatabaseList)
            {
                var clip = audioDatabase.AudioClipList.FirstOrDefault(x => x.name == clipName);
                if (clip != null)
                {
                    return clip;
                }
            }

            return null;
        }
        #endregion

        #region > Method

        public override void Awake()
        {
            base.Awake();
            
            _ = AudioDictionary;
        }

        public void Play(Object sender, T audioType, string audioName)
        {
            Play(audioType, audioName);
        }

        private void Play(T audioType, string audioName)
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
            _audioDictionary ??= Init();
        
        private Dictionary<string, AudioSource> Init()
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

        #region > AudioDatabase
#if UNITY_EDITOR
        protected void AudioDatabaseFindOrCreate()
        {
            Util.FindAllAssets(this, ref audioDatabaseList );

            var audioDatabaseCount = audioDatabaseList.Count;
            switch (audioDatabaseCount)
            {
                case 0:  // create
                    AudioDatabaseCreate(ref audioDatabaseList, out var savePath);
                    AudioDatabaseReport("Create!");
                    AudioDatabaseReport($"Save Path : {savePath}");
                    break;
                case 1:  // good
                    AudioDatabaseReport("Find Success!");
                    break;
                default: // warring
                    AudioDatabaseReport("Multiple Databases Exist!");
                    break;
            }
        }

        private void AudioDatabaseCreate(ref List<AudioDatabase> audioDatabases, out string savePath)
        {
            savePath = Path.Combine(Application.dataPath, "Resources");
        }

        private void AudioDatabaseReport(string message)
        {
            Debug.Log(message);
        }
#endif
        #endregion
    }
}

