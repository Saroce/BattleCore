//------------------------------------------------------------
//        File:  AddAvatarViewSystem.cs
//       Brief:  AddAvatarViewSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-19
//============================================================

using System.Collections.Generic;
using Battle.View.Base;
using Battle.View.Base.System;
using Battle.View.Constant;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Battle.View.Thing.System.Avatar
{
    internal class AddAvatarViewSystem : ViewReactiveSystem<ViewThingEntity>
    {
        public AddAvatarViewSystem(ViewContexts contexts) : base(contexts, contexts.viewThing) {
            
        }

        protected override ICollector<ViewThingEntity> GetTrigger(IContext<ViewThingEntity> context) {
            return context.CreateCollector(ViewThingMatcher.AvatarAsset.Added());
        }

        protected override bool Filter(ViewThingEntity entity) {
            return entity.hasPosition 
                   && entity.hasRotation 
                   && entity.hasAvatarAsset
                   && entity.hasThingType
                   && !entity.hasAvatarView;
        }

        protected override void Execute(List<ViewThingEntity> entities) {
            var root = GameObjectRoots.GetRoot(ViewConst.ThingsRootName);
            var pools = Contexts.GetBattleContext().SpawnPool;

            foreach (var entity in entities) {
                var assetPath = entity.avatarAsset.Value;
                
                var container = new GameObject();
                container.Link(entity);
                container.transform.SetParent(root.transform, false);
                container.transform.localPosition = entity.position.Value.ToUnityVector3();
                container.name = $"{entity.thingType.Value.ToString()}({entity.id.Value})";

                var viewObject = pools[assetPath].Spawn();
                viewObject.transform.SetParent(container.transform, false);
                viewObject.transform.localRotation = entity.rotation.Value.ToUnityQuaternion();
                
                entity.AddAvatarView(container, viewObject);
            }
        }
    }
}