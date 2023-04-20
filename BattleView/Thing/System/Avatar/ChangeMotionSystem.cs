//------------------------------------------------------------
//        File:  ChangeMotionSystem.cs
//       Brief:  ChangeMotionSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-20
//============================================================

using System.Collections.Generic;
using Battle.View.Base.System;
using Battle.View.Constant;
using Entitas;
using UnityEngine;

namespace Battle.View.Thing.System.Avatar
{
    internal class ChangeMotionSystem : ViewReactiveSystem<ViewThingEntity>
    {
        public ChangeMotionSystem(ViewContexts contexts) : base(contexts, contexts.viewThing) {
        }

        protected override ICollector<ViewThingEntity> GetTrigger(IContext<ViewThingEntity> context) {
            return context.CreateCollector(ViewThingMatcher.AvatarMotion);
        }

        protected override bool Filter(ViewThingEntity entity) {
            return entity.hasAvatarView && entity.hasAvatarMotion;
        }

        protected override void Execute(List<ViewThingEntity> entities) {
            foreach (var entity in entities) {
                var animator = entity.avatarView.ViewObject.GetComponentInChildren<Animator>();
                if (animator == null) {
                    LogWarning(LogTagDef.ThingLogTag,
                        $"In view object: {entity.avatarView.ViewObject.name} not get animator!");
                    continue;
                }

                var motionName = entity.avatarMotion.Value;
                var stateName = $"{MotionName.DefaultLayerName}.{motionName}";
                var layerIndex = animator.GetLayerIndex(MotionName.DefaultLayerName);
                var stateId = Animator.StringToHash(stateName);
                if (animator.HasState(layerIndex, stateId)) {
                    animator.Play(stateId);
                }
                else {
                    LogWarning(LogTagDef.ThingLogTag,
                        $"In view object: {entity.avatarView.ViewObject.name} contain animator not has motion: {stateName}");
                }
            }
        }
    }
}