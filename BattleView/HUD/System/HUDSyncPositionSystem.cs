//------------------------------------------------------------
//        File:  HUDSyncPositionSystem.cs
//       Brief:  HUDSyncPositionSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-20
//============================================================

using Battle.View.Base.System;
using Battle.View.Constant;
using Entitas;
using UnityEngine;

namespace Battle.View.HUD.System
{
    internal class HUDSyncPositionSystem : ViewExecuteSystem
    {
        private readonly IGroup<ViewHUDEntity> _group;

        public HUDSyncPositionSystem(ViewContexts contexts) : base(contexts) {
            var matchers = ViewHUDMatcher.AllOf(
                ViewHUDMatcher.HUDView,
                ViewHUDMatcher.HUDOwner,
                ViewHUDMatcher.HUDBindPoint,
                ViewHUDMatcher.HUDOffset,
                ViewHUDMatcher.HUDPositionSyncWithOwner
            );
            _group = contexts.viewHUD.GetGroup(matchers);
        }

        public override void Execute() {
            var battleContext = Contexts.GetBattleContext();
            var hudCamera = battleContext.HUDCamera;
            var sceneCamera = battleContext.SceneCamera;
            var hudRoot = battleContext.HUDRoot;
            var viewConfig = Contexts.GetViewConfig();

            foreach (var entity in _group.GetEntities()) {
                var ownerId = entity.hUDOwner.Id;
                var owner = Contexts.viewThing.GetEntityWithId(ownerId);
                if (owner == null || !owner.hasAvatarView) {
                    continue;
                }

                var view = entity.hUDView.Value;
                var worldPos = owner.avatarView.Container.transform.position + viewConfig.GetBindPoint(entity.hUDBindPoint.Value);
                var screenPos = sceneCamera.WorldToScreenPoint(worldPos);

                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(hudRoot.transform as RectTransform,
                        screenPos, hudCamera, out var localPos)) {
                    view.transform.position = hudRoot.transform.TransformPoint(localPos) + entity.hUDOffset.Value;
                }
            }
        }
    }
}