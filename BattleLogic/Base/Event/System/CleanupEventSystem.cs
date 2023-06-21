//------------------------------------------------------------
//        File:  CleanupEventSystem.cs
//       Brief:  CleanupEventSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.System;
using Entitas;

namespace Battle.Logic.Base.Event.System
{
    internal class CleanupEventSystem : LogicCleanupSystem
    {
        private static readonly IMatcher<LogicEventEntity> EventMatcher = LogicEventMatcher.Destroyed;

        private readonly IGroup<LogicEventEntity> _group;

        public CleanupEventSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicEvent.GetGroup(EventMatcher);
        }

        public override void Cleanup() {
            foreach (var eventEntity in _group.GetEntities()) {
                if (eventEntity.hasEventContext) {
                    Contexts.RefPoolManager().TryReturn(eventEntity.eventContext.Value);
                }
                eventEntity.Destroy();
            }
        }
    }
}