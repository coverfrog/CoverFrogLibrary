#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CoverFrog
{
    [CustomEditor(typeof(AuctionSystem))]
    public class AuctionSystemEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var sys = (AuctionSystem)target;

            Current();
        }

        private static void Current()
        {
            EditorGUILayout.LabelField("[ Current ]");
            EditorGUILayout.LabelField(AuctionSystem.Current == null ? 
                "{ Null, Null }" : 
                $"{{ {AuctionSystem.Current.CodeName}, {AuctionSystem.Current.CurrentPrice} }}");
        }
    }
}
#endif
