//------------------------------------------------------------
//        File:  ViewContexts.cs
//       Brief:  ViewContexts
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Message;
using Battle.View.Base;
using Core.Lite.DataSystem.Config;
using Core.Lite.RefPool;
using Core.Lite.RefPool.Allocator;
using Flux.Runtime;

namespace Battle.View
{
    public class ViewContexts : Contexts
    {
        private readonly ViewController _controller;
        private readonly FRuntimeSetting _fRuntimeSetting;
        
        public ViewContexts(ViewController controller) {
            _controller = controller;

            var battleContext = GetBattleContext();
            _fRuntimeSetting = new FRuntimeSetting() {
                AudioPlayerFactory = battleContext.FluxAudioPlayerFactory,
                FluxAssetLoader = battleContext.FluxAssetLoader,
                ObjectRootName = battleContext.FluxObjectRootName,
                ControlAnimator = true
            };
        }
        
        internal ViewController GetController() {
            return _controller;
        }

        internal BattleViewContext GetBattleContext() {
            return GetController().GetBattleContext();
        }
        
        internal bool TryDequeueMessage(out IBattleMessage message) {
            return GetController().TryDequeueMessage(out message);
        }

        internal IConfigReader GetConfigReader() {
            return GetController().GetConfigReader();
        }

        internal BattleViewConfig GetViewConfig() {
            return GetController().GetViewConfig();
        }
        
        public ulong GetIndependentId() {
            return GetController().GetIndependentId();
        }

        public FRuntimeSetting GetFluxRuntimeSetting() {
            return _fRuntimeSetting;
        }
        
        internal IRefPool<T> RefPool<T>() where T : class, new() {
            return GetController().GetRefPool<T>();
        }
        
        /// <summary>
        /// 获取List对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal IRefPool<List<T>> ListPool<T>() {
            return GetController().GetRefPool<List<T>, ListAllocator<T>>();
        }

        /// <summary>
        /// 获取HashSet对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal IRefPool<HashSet<T>> HashSetPool<T>() {
            return GetController().GetRefPool<HashSet<T>, HashSetAllocator<T>>();
        }

        /// <summary>
        /// 获取Stack对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal IRefPool<Stack<T>> StackPool<T>() {
            return GetController().GetRefPool<Stack<T>, StackAllocator<T>>();
        }

        public IRefPoolManager RefPoolManager() {
            return GetController().RefPoolManager();
        }
    }
}