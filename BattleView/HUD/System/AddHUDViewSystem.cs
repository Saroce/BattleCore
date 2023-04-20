//------------------------------------------------------------
//        File:  AddHUDViewSystem.cs
//       Brief:  AddHUDViewSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-20
//============================================================

using System.Collections.Generic;
using Battle.View.Base.MonoBehaviourEx;
using Battle.View.Base.System;
using Battle.View.Constant;
using Core.Unity.Extensions;
using Entitas;
using UnityEngine;

namespace Battle.View.HUD.System
{
    internal class AddHUDViewSystem : ViewReactiveSystem<ViewHUDEntity>
    {
        public AddHUDViewSystem(ViewContexts contexts) : base(contexts, contexts.viewHUD) {
        }

        protected override ICollector<ViewHUDEntity> GetTrigger(IContext<ViewHUDEntity> context) {
            return context.CreateCollector(ViewHUDMatcher.HUDAsset);
        }

        protected override bool Filter(ViewHUDEntity entity) {
            return entity.hasHUDPosition && entity.hasHUDOffset && entity.hasHUDBindPoint;
        }

        protected override void Execute(List<ViewHUDEntity> entities) {
            var battleContext = Contexts.GetBattleContext();
            var hudRoot = battleContext.HUDRoot;
            var hudCamera = battleContext.HUDCamera;
            var pools = battleContext.SpawnPool;
            var sceneCamera = battleContext.SceneCamera;
            var viewConfigs = Contexts.GetViewConfig();

            foreach (var entity in entities) {
                var assetPath = entity.hUDAsset.Value;
                var gameObject = pools[assetPath].Spawn();
                gameObject.transform.SetParent(hudRoot.transform, false);
                gameObject.name = assetPath;

                var hudWorldPos = entity.hUDPosition.Value + viewConfigs.GetBindPoint(entity.hUDBindPoint.Value);
                var screenPos = sceneCamera.WorldToScreenPoint(hudWorldPos);

                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(hudRoot.transform as RectTransform,
                        screenPos, hudCamera, out var localPos)) {
                    gameObject.transform.position = hudRoot.transform.TransformPoint(localPos) + entity.hUDOffset.Value;
                }

                var view = gameObject.GetOrAddComponent<HUDView>();
                view.Link(entity);
                view.PlayAnimation(entity.isHUDAutoDestroyWhenPlayFinished);
                
                entity.AddHUDView(view);
            }
        }
    }
}