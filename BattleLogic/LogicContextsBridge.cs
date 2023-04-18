//------------------------------------------------------------
//        File:  LogicContextsBridge.cs
//       Brief:  LogicContextsBridge
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using System.Diagnostics;
using Core.Lite.Base;
using Core.Lite.Loggers;

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