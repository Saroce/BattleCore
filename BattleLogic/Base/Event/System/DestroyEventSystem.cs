//------------------------------------------------------------
//        File:  DestroyEventSystem.cs
//       Brief:  DestroyEventSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.System;
using Entitas;

namespace Battle.Logic.Base.Event.System
{
    internal class DestroyEventSystem : LogicExecuteSystem
    {
        private static readonly IMatcher<LogicEventEntity> EventMatcher = LogicEventMatcher.EventFrameIndex;

        private readonly IGroup<LogicEventEntity> _group;

        public DestroyEventSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicEvent.GetGroup(EventMatcher);
        }

        public override void Execute() {
            var curFrameIndex = Contexts.GetFrameCounter().FrameIndex;
            foreach (var eventEntity in _group.GetEntities()) {
                // 每个事件只有一帧的有效期, 标记为Destroyed在Cleanup中销毁对应实体
                if (eventEntity.eventFrameIndex.Value != curFrameIndex) {
                    eventEntity.isDestroyed = true;
                }
            }
        }
    }
}