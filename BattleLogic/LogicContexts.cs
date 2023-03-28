//------------------------------------------------------------
//        File:  LogicContexts.cs
//       Brief:  LogicContexts
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Battle.Logic.Base;
using Battle.Logic.Base.Clock;

namespace Battle.Logic
{
    public class LogicContexts : Contexts
    {
        private readonly LogicController _controller;

        public LogicContexts(LogicController controller) {
            _controller = controller;
        }

        public LogicController GetController() {
            return _controller;
        }

        public BattleContext GetBattleContext() {
            return GetController().GetBattleContext();
        }

        public ulong GetIndependentId() {
            return GetController().GetIndependentId();
        }

        public IClock GetClock() {
            return GetController().GetClock();
        }
    }
}