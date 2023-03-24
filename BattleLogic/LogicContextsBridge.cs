//------------------------------------------------------------
//        File:  LogicContextsBridge.cs
//       Brief:  LogicContextsBridge
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Core.Lite.Base;

namespace Battle.Logic
{
    internal class LogicContextsBridge : BaseObject<LogicContexts>
    {
        protected LogicContexts Contexts { get; private set; }
        
        protected override void OnDestroy() {
            Contexts = null;
        }

        protected override void OnCreate(LogicContexts contexts) {
            Contexts = contexts;
        }
    }
}