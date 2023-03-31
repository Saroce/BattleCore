//------------------------------------------------------------
//        File:  LogicContexts.cs
//       Brief:  LogicContexts
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Battle.Common.Context.Message;
using Battle.Logic.Base;
using Battle.Logic.Base.Clock;
using Core.Lite.RefPool;

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
    }
}