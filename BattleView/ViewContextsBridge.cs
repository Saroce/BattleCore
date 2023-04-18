//------------------------------------------------------------
//        File:  ViewContextsBridge.cs
//       Brief:  ViewContextsBridge
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using System.Diagnostics;
using Battle.View.Base;
using Core.Lite.Base;
using Core.Lite.DataSystem.Config;
using Core.Lite.Loggers;
using Logger = Battle.View.Base.Logger;

namespace Battle.View
{
    internal class ViewContextsBridge : BaseObject<ViewContexts>
    {
        protected ViewContexts Contexts { get; private set; }

        protected override void OnCreate(ViewContexts contexts) {
            Contexts = contexts;
        }
        
        protected IConfigReader ConfigReader => Contexts.GetConfigReader();
        
        protected BattleViewConfig ViewConfig => Contexts.GetViewConfig();
        
        protected override void OnDestroy() {
            Contexts = null;
        }
        
        [Conditional("FULL_LOG")]
        protected void LogDebug(LogTag tag, string content, params object[] args) {
            Logger.LogDebug(tag, content, args);
        }

        protected void LogInfo(LogTag tag, string content, params object[] args) {
            Logger.LogInfo(tag, content, args);
        }

        protected void LogWarning(LogTag tag, string content, params object[] args) {
            Logger.LogWarning(tag, content, args);
        }

        protected void LogError(LogTag tag, string content, params object[] args) {
            Logger.LogError(tag, content, args);
        }
    }
}
