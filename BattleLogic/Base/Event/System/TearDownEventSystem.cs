//------------------------------------------------------------
//        File:  TearDownEventSystem.cs
//       Brief:  TearDownEventSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.System;

namespace Battle.Logic.Base.Event.System
{
    internal class TearDownEventSystem : LogicTearDownSystem
    {
        public TearDownEventSystem(LogicContexts contexts) : base(contexts) {
        }

        public override void TearDown() {
            foreach (var eventEntity in Contexts.logicEvent.GetEntities()) {
                eventEntity.Destroy();
            }
        }
    }
}