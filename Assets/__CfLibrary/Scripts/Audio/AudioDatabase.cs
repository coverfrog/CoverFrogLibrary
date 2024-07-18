using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoverFrog
{
    [CreateAssetMenu(menuName = "Cf/Audio/Database", fileName = "Audio Database")]
    public class AudioDatabase : ScriptableObject
    {
        [SerializeField] private List<AudioClip> audioClipList;

        public IReadOnlyList<AudioClip> AudioClipList => audioClipList;
        
#if UNITY_EDITOR
        [ContextMenu("[ Cf ] Find All Audio Clip")]
        private void InitInspector()
        {
            Util.FindAllAssets(this, ref audioClipList);
        }
#endif
    }
}
