//------------------------------------------------------------
//        File:  GameObjectRoots.cs
//       Brief:  GameObjectRoots
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-19
//============================================================

using System.Collections.Generic;
using UnityEngine;

namespace Battle.View.Base
{
    internal static class GameObjectRoots
    {
        private static readonly Dictionary<string, GameObject> Roots = new Dictionary<string, GameObject>();
        
        private static GameObject Parent { get; set; }

        private const string RootParentName = "DynamicRoots";

        private static GameObject GetOrCreateRoot(string name) {
            if (Roots.ContainsKey(name) && Roots[name]) {
                return Roots[name];
            }

            var root = new GameObject(name);
            root.transform.SetParent(Parent.transform, false);
            Roots[name] = root;
            return root;
        }

        public static GameObject GetRoot(string rootName) {
            if (!Parent) {
                Parent = GameObject.Find(RootParentName) ?? new GameObject(RootParentName);
                Roots.Clear();
            }

            return GetOrCreateRoot(rootName);
        }
    }
}
