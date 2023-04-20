//------------------------------------------------------------
//        File:  SyncAvatarViewPositionSystem.cs
//       Brief:  SyncAvatarViewPositionSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-20
//============================================================

using Battle.View.Base;
using Battle.View.Base.System;
using Entitas;
using UnityEngine;

namespace Battle.View.Thing.System.Avatar
{
    internal class SyncAvatarViewPositionSystem : ViewExecuteSystem
    {
        private readonly IGroup<ViewThingEntity> _group;

        public SyncAvatarViewPositionSystem(ViewContexts contexts) : base(contexts) {
            _group = contexts.viewThing.GetGroup(ViewThingMatcher.AllOf(
                ViewThingMatcher.AvatarView,
                ViewThingMatcher.Position,
                ViewThingMatcher.ThingType
            ));
        }

        public override void Execute() {
            foreach (var entity in _group.GetEntities()) {
                var transform = entity.avatarView.Container.transform;
                var destPos = entity.position.Value.ToUnityVector3();

                transform.position = Vector3.Lerp(transform.position, destPos, Time.deltaTime * ViewConfig.LerpSpeed);
            }
        }
    }
}