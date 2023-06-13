﻿//------------------------------------------------------------
//        File:  ThingRotationUpdatedSystem.cs
//       Brief:  ThingRotationUpdatedSystem
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
    internal class ThingRotationUpdatedSystem : LogicBaseSystem, IInitializeSystem, ITearDownSystem
    {
        private static readonly IMatcher<LogicThingEntity> ThingMatcher = LogicThingMatcher.AllOf(
            LogicThingMatcher.Id,
            LogicThingMatcher.Rotation);

        private readonly IGroup<LogicThingEntity> _group;

        public ThingRotationUpdatedSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicThing.GetGroup(ThingMatcher);
        }

        public void Initialize() {
            _group.OnEntityAdded += OnEntityAdded;
        }

        public void TearDown() {
            _group.OnEntityAdded -= OnEntityAdded;
        }

        private void OnEntityAdded(IGroup<LogicThingEntity> @group, LogicThingEntity entity, int index, IComponent component) {
            var message = RefPool<ThingRotationMessage>().Get();
            message.Id = entity.id.Value;
            message.ThingType = entity.GetThingType();
            message.Rotation = entity.rotation.Value;
            SendMessage(message);
        }
    }
}