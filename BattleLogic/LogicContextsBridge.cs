//------------------------------------------------------------
//        File:  LogicContextsBridge.cs
//       Brief:  LogicContextsBridge
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using System.Collections.Generic;
using System.Diagnostics;
using Battle.Common.Context.Message;
using Core.Lite.Base;
using Core.Lite.DataSystem;
using Core.Lite.DataSystem.Config;
using Core.Lite.Loggers;
using Core.Lite.RefPool;

namespace Battle.Logic
{
    internal class LogicContextsBridge : BaseObject<LogicContexts>
    {
        protected LogicContexts Contexts { get; private set; }
        
        protected override void OnCreate(LogicContexts contexts) {
            Contexts = contexts;
        }
        
        protected override void OnDestroy() {
            Contexts = null;
        }

        protected IConfigReader ConfigReader => Contexts.GetConfigReader();

        protected IDataReader DataReader => Contexts.GetDataReader();

        protected void SendMessage(IBattleMessage message) {
            Contexts.SendMessage(message);
        }

        protected IRefPool<T> RefPool<T>() where T : class, new() {
            return Contexts.RefPool<T>();
        }
        
        public IRefPool<List<T>> ListPool<T>() {
            return Contexts.ListPool<T>();
        }
        
        public IRefPool<HashSet<T>> HashSetPool<T>() {
            return Contexts.HashSetPool<T>();
        }

        [Conditional("FULL_LOG")]
        protected void LogDebug(LogTag tag, string content, params object[] args) {
            Contexts.GetLogger().LogDebug(tag, content, 2, args);
        }

        protected void LogInfo(LogTag tag, string content, params object[] args) {
            Contexts.GetLogger().LogInfo(tag, content, 2, args);
        }

        protected void LogWarning(LogTag tag, string content, params object[] args) {
            Contexts.GetLogger().LogWarning(tag, content, 2, args);
        }

        protected void LogError(LogTag tag, string content, params object[] args) {
            Contexts.GetLogger().LogError(tag, content, 2, args);
        }
    }
}