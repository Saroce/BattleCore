//------------------------------------------------------------
//        File:  RotateAvatarViewSystem.cs
//       Brief:  RotateAvatarViewSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using System.Collections.Generic;
using Battle.Common.Constant;
using Battle.View.Base;
using Battle.View.Base.System;
using DG.Tweening;
using Entitas;

namespace Battle.View.Thing.System.Avatar
{
    internal class RotateAvatarViewSystem : ViewReactiveSystem<ViewThingEntity>
    {
        public RotateAvatarViewSystem(ViewContexts contexts) : base(contexts, contexts.viewThing) {

        }

        protected override ICollector<ViewThingEntity> GetTrigger(IContext<ViewThingEntity> context) {
            return context.CreateCollector(ViewThingMatcher.Rotation);
        }

        /// <summary>
        /// 控制非Bullet类Thing的旋转
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override bool Filter(ViewThingEntity entity) {
            return entity.hasAvatarView
                   && entity.hasRotation 
                   && entity.hasThingType
                   && entity.thingType.Value != ThingType.Bullet;
        }

        /// <summary>
        /// 控制符合条件的entities进行旋转
        /// </summary>
        /// <param name="entities"></param>
        protected override void Execute(List<ViewThingEntity> entities) {
            foreach (var entity in entities) {
                if (entity.hasAvatarRotateTween) {
                    DOTween.Kill(entity.avatarRotateTween.TweenId);
                }

                var tweenId = Contexts.GetIndependentId();
                var destRotation = entity.rotation.Value.ToUnityQuaternion();

                var transform = entity.avatarView.ViewObject.transform;
                var time = ViewConfigs.AnimationTweenDuration;
                transform.DOLocalRotateQuaternion(destRotation, time).SetId(tweenId);
                entity.ReplaceAvatarRotateTween(tweenId);
            }
        }
    }
}