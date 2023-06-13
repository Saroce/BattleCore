//------------------------------------------------------------
//        File:  LogicContexts.cs
//       Brief:  LogicContexts
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using System.Collections.Generic;
using System.Diagnostics;
using Battle.Common.Context.Command;
using Battle.Common.Context.Message;
using Battle.Logic.Base;
using Battle.Logic.Base.Clock;
using Core.Lite.DataSystem;
using Core.Lite.DataSystem.Config;
using Core.Lite.Loggers;
using Core.Lite.RefPool;
using Core.Lite.RefPool.Allocator;
using UnityEngine.Pool;
using Logger = Battle.Logic.Base.Logger;

namespace Battle.Logic
{
    public class LogicContexts : Contexts
    {
        private readonly LogicController _controller;

        public LogicContexts(LogicController controller) {
            _controller = controller;
        }

        internal LogicController GetController() {
            return _controller;
        }

        internal BattleContext GetBattleContext() {
            return GetController().GetBattleContext();
        }

        internal ulong GetIndependentId() {
            return GetController().GetIndependentId();
        }

        internal IClock GetClock() {
            return GetController().GetClock();
        }

        internal void SendMessage(IBattleMessage message) {
            GetController().EnqueueMessage(message);
        }
        
        internal IRefPool<T> GetRefPool<T>() where T : class, new() {
            return GetController().GetRefPool<T>();
        }
        
        /// <summary>
        /// 获取List对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRefPool<List<T>> ListPool<T>() {
            return GetController().ObjectPool<List<T>, ListAllocator<T>>();
        }

        /// <summary>
        /// 获取HashSet对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRefPool<HashSet<T>> HashSetPool<T>() {
            return GetController().ObjectPool<HashSet<T>, HashSetAllocator<T>>();
        }

        /// <summary>
        /// 获取Stack对象池
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRefPool<Stack<T>> StackPool<T>() {
            return GetController().ObjectPool<Stack<T>, StackAllocator<T>>();
        }

        public IRefPoolManager RefPoolManager() {
            return GetController().RefPoolManager();
        }
        
        internal Logger GetLogger() {
            return GetController().GetLogger();
        }

        internal IConfigReader GetConfigReader() {
            return GetController().GetConfigReader();
        }

        internal IDataReader GetDataReader() {
            return GetController().GetDataReader();
        }
        
        internal bool TryDequeueRequest(out IBattleRequest request) {
            return GetController().TryDequeueRequest(out request);
        }
        
        /// <summary>
        /// Debug日志输出
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        /// <param name="args"></param>
        [Conditional("FULL_LOG")]
        public void LogDebug(LogTag tag, string content, params object[] args) {
            GetLogger().LogDebug(tag, content, 2, args);
        }
        
        /// <summary>
        /// Warning日志输出
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        /// <param name="args"></param>
        public void LogWarning(LogTag tag, string content, params object[] args) {
            GetLogger().LogWarning(tag, content, 2, args);
        }

        /// <summary>
        /// Error日志输出
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        /// <param name="args"></param>
        public void LogError(LogTag tag, string content, params object[] args) {
            GetLogger().LogError(tag, content, 2, args);
        }
    }
}