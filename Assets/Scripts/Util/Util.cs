using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace CoverFrog.UtilSys
{
    public static class Util 
    {
        public static void FindAllAssets<T>(Object sender, ref List<T> source) where T : Object
        {
            // guid ( unity in locate )
            var assets = new List<T>();
            var guids = AssetDatabase.FindAssets($"t:{typeof(T)}");
            
            // load asset
            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);

                if (asset.GetType() == typeof(T))
                {
                    assets.Add(asset);
                }

                EditorUtility.SetDirty(sender);
                AssetDatabase.SaveAssets();
            }

            source = assets;
        }
    }
}
