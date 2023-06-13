//------------------------------------------------------------
//        File:  UpdateIdleMotionSystem.cs
//       Brief:  更新默认Idle动作
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using System.Collections.Generic;
using Battle.Logic.Base.System;
using Battle.Logic.Thing.Extension;
using Entitas;

namespace Battle.Logic.Thing.Behaviour.State.Idle.System
{
    internal class UpdateIdleMotionSystem : LogicReactiveSystem<LogicThingEntity>
    {
        private static readonly IMatcher<LogicThingEntity> ThingMatcher = LogicThingMatcher.IdleMotionName;
        
        public UpdateIdleMotionSystem(LogicContexts contexts) : base(contexts, contexts.logicThing) {
            
        }

        protected override ICollector<LogicThingEntity> GetTrigger(IContext<LogicThingEntity> context) {
            return context.CreateCollector(ThingMatcher.AddedOrRemoved());
        }

        protected override bool Filter(LogicThingEntity entity) {
            return entity.hasId && entity.hasStateMachine;
        }

        protected override void Execute(List<LogicThingEntity> entities) {
            foreach (var thingEntity in entities) {
                thingEntity.Idle(Contexts, false);
            }
        }
    }
}