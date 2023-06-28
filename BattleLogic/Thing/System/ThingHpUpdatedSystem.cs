//------------------------------------------------------------
//        File:  ThingHpUpdatedSystem.cs
//       Brief:  ThingHpUpdatedSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using Battle.Common.Context.Message.Thing;
using Battle.Logic.Base.System;
using Battle.Logic.Thing.Component.Property;
using Battle.Logic.Thing.Extension;
using Entitas;

namespace Battle.Logic.Thing.System
{
    internal class ThingHpUpdatedSystem : LogicBaseSystem, IInitializeSystem, ITearDownSystem
    {
        private static readonly IMatcher<LogicThingEntity> ThingMatcher = LogicThingMatcher.AllOf(
            LogicThingMatcher.Id,
            LogicThingMatcher.HealPoint
        );

        private readonly IGroup<LogicThingEntity> _group;

        public ThingHpUpdatedSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicThing.GetGroup(ThingMatcher);
        }

        public void Initialize() {
            _group.OnEntityUpdated += OnEntityUpdated;
        }

        public void TearDown() {
            _group.OnEntityUpdated -= OnEntityUpdated;
        }

        private void OnEntityUpdated(IGroup<LogicThingEntity> @group, LogicThingEntity entity, int index,
            IComponent oldComponent, IComponent newComponent) {
            var mes = RefPool<ThingHpUpdateMessage>().Get();
            mes.Id = entity.id.Value;
            mes.ThingType = entity.GetThingType();
            mes.OldValue = ((HealPointComponent)oldComponent).Current;
            mes.NewValue = ((HealPointComponent)newComponent).Current;
            mes.Maximum = ((HealPointComponent)newComponent).Maximum;
            SendMessage(mes);
        }
    }
}