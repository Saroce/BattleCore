//------------------------------------------------------------
//        File:  LogicEventSystem.cs
//       Brief:  LogicEventSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using System.Collections.Generic;
using Battle.Logic.Base.Event;
using Entitas;

namespace Battle.Logic.Base.System
{
    internal abstract class LogicEventSystem<T> : LogicReactiveSystem<LogicEventEntity> where T : IEventContext
    {
        private static readonly IMatcher<LogicEventEntity> EventMatcher = LogicEventMatcher.EventContext;

        protected LogicEventSystem(LogicContexts contexts) : base(contexts, contexts.logicEvent) {
        }

        protected override ICollector<LogicEventEntity> GetTrigger(IContext<LogicEventEntity> context) {
            return context.CreateCollector(EventMatcher);
        }

        protected override bool Filter(LogicEventEntity entity) {
            return entity.hasEventContext;
        }

        protected override void Execute(List<LogicEventEntity> entities) {
            foreach (var eventEntity in entities) {
                if (eventEntity.eventContext.Value is T context) {
                    OnEvent(context);
                }
            }
        }

        protected abstract void OnEvent(T context);
    }

    internal abstract class LogicEventSystem<T1, T2> : LogicReactiveSystem<LogicEventEntity>
        where T1 : IEventContext where T2 : IEventContext
    {
        private static readonly IMatcher<LogicEventEntity> EventMatcher = LogicEventMatcher.EventContext;

        protected LogicEventSystem(LogicContexts contexts)
            : base(contexts, contexts.logicEvent) {
        }

        protected override ICollector<LogicEventEntity> GetTrigger(IContext<LogicEventEntity> context) {
            return context.CreateCollector(EventMatcher);
        }

        protected override bool Filter(LogicEventEntity entity) {
            return entity.hasEventContext;
        }

        protected override void Execute(List<LogicEventEntity> entities) {
            foreach (var eventEntity in entities) {
                switch (eventEntity.eventContext.Value) {
                    case T1 context:
                        OnEvent(context);
                        break;
                    case T2 context:
                        OnEvent(context);
                        break;
                }
            }
        }

        protected abstract void OnEvent(T1 context);
        protected abstract void OnEvent(T2 context);
    }
}