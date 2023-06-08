//------------------------------------------------------------
//        File:  LogicContexts.cs
//       Brief:  LogicContexts
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using System.Diagnostics;
using Battle.Common.Context.Message;
using Battle.Logic.Base;
using Battle.Logic.Base.Clock;
using Core.Lite.DataSystem;
using Core.Lite.DataSystem.Config;
using Core.Lite.Loggers;
using Core.Lite.RefPool;
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
        
        internal Logger GetLogger() {
            return GetController().GetLogger();
        }

        internal IConfigReader GetConfigReader() {
            return GetController().GetConfigReader();
        }

        internal IDataReader GetDataReader() {
            return GetController().GetDataReader();
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