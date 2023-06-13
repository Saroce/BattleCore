//------------------------------------------------------------
//        File:  ThingPositionUpdateSystem.cs
//       Brief:  ThingPositionUpdateSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using Battle.Common.Context.Message.Thing;
using Battle.Logic.Base.System;
using Battle.Logic.Thing.Extension;
using Entitas;

namespace Battle.Logic.Thing.System
{
    internal class ThingPositionUpdateSystem : LogicBaseSystem, IInitializeSystem, ITearDownSystem
    {
        private static readonly IMatcher<LogicThingEntity> ThingMatcher =
            LogicThingMatcher.AllOf(LogicThingMatcher.Id, LogicThingMatcher.Position);

        private readonly IGroup<LogicThingEntity> _group;

        public ThingPositionUpdateSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicThing.GetGroup(ThingMatcher);
        }

        public void Initialize() {
            _group.OnEntityAdded += OnEntityAdd;
        }

        public void TearDown() {
            _group.OnEntityAdded -= OnEntityAdd;
        }

        private void OnEntityAdd(IGroup<LogicThingEntity> @group, LogicThingEntity entity, int index,
            IComponent component) {
            var message = RefPool<ThingPositionMessage>().Get();
            message.Id = entity.id.Value;
            message.ThingType = entity.GetThingType();
            message.Position = entity.position.Value;
            SendMessage(message);
        }
    }
}