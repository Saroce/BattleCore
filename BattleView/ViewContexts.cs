//------------------------------------------------------------
//        File:  ViewContexts.cs
//       Brief:  ViewContexts
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Battle.Common.Context.Message;
using Battle.View.Base;
using Core.Lite.DataSystem.Config;
using Core.Lite.RefPool;

namespace Battle.View
{
    public class ViewContexts : Contexts
    {
        private readonly ViewController _controller;
        
        public ViewContexts(ViewController controller) {
            _controller = controller;
        }
        
        internal ViewController GetController() {
            return _controller;
        }

        internal BattleContext GetBattleContext() {
            return GetController().GetBattleContext();
        }

        internal IRefPoolManager GetRefPoolManager() {
            return GetController().GetRefPoolManager();
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
    }
}