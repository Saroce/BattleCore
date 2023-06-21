//------------------------------------------------------------
//        File:  LogicImmediateEventSystem.cs
//       Brief:  LogicImmediateEventSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.Event;
using Entitas;

namespace Battle.Logic.Base.System
{
    internal abstract class LogicImmediateEventSystem<T> : LogicInitializeSystem where T : IEventContext
    {
        private static readonly IMatcher<LogicEventEntity> EventMatcher = LogicEventMatcher.EventContext;

        private readonly IGroup<LogicEventEntity> _group;

        protected LogicImmediateEventSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicEvent.GetGroup(EventMatcher);
        }

        public override void Initialize() {
            _group.OnEntityAdded += OnEntityAdd;
        }

        public override void TearDown() {
            _group.OnEntityAdded -= OnEntityAdd;
        }

        private void OnEntityAdd(IGroup<LogicEventEntity> @group, LogicEventEntity entity, int index,
            IComponent component) {
            if (entity.eventContext.Value is T context) {
                OnEvent(context);
            }
        }
        
        protected abstract void OnEvent(T context);
    }
}