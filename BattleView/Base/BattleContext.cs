//------------------------------------------------------------
//        File:  BattleContext.cs
//       Brief:  BattleContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Core.Bundler;
using Core.Lite.DataSystem;
using Core.Lite.RefPool;
using Core.Unity.SpawnPool;
using Flux.Runtime.Adapter.Audios;
using Flux.Runtime.Adapter.Loaders;
using UnityEngine;

namespace Battle.View.Base
{
    public sealed class BattleContext
    {
        public int BattleId;
        public int Seed;
        public string ViewConfigJson;
        public string ConfigPath;
        
        public IRefPoolManager RefPoolManager;
        public IBundler Bundler;
        public ISpawnPool SpawnPool;
        public IDataReader DataReader;
        public IAudioPlayerFactory FluxAudioPlayerFactory;
        public IAssetLoader FluxAssetLoader;
        public string FluxObjectRootName;
        public GameObject HUDRoot;
        public GameObject CameraRoot;
        public Camera HUDCamera;
        public Camera SceneCamera;
    }
}