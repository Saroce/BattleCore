//------------------------------------------------------------
//        File:  OnHpUpdate.cs
//       Brief:  处理血量变化的消息
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using System;
using Battle.Common.Context.Message.Thing;
using Battle.View.Base;
using Battle.View.Constant;

namespace Battle.View.Input.System.Processor
{
    internal class OnHpUpdate : MessageProcessor<ThingHpUpdateMessage>
    {
        protected override void OnProcess(ThingHpUpdateMessage message) {
            var hpHUD = GetOrCreateHPHUDEntity(message);
            // 血量变化
            hpHUD?.ReplaceHUDHP(Math.Max((int)message.NewValue, 0), message.Maximum.AsInt());
        }

        private ViewHUDEntity GetOrCreateHPHUDEntity(ThingHpUpdateMessage message) {
            var huds = Contexts.viewHUD.GetEntitiesWithHUDOwner(message.Id);
            foreach (var hudEntity in huds) {
                if (hudEntity.hasHUDHP && !hudEntity.isDestroyed) {
                    return hudEntity;
                }
            }

            var targetEntity = Contexts.viewThing.GetEntityWithId(message.Id);
            if (targetEntity == null) {
                return null;
            }

            if (targetEntity.isDestroyed || !targetEntity.hasAvatarView || !targetEntity.hasPosition) {
                return null;
            }
            
            // 创建血条HUD
            var hud = Contexts.viewHUD.CreateEntity();
            hud.AddHUDAsset(ViewConfig.HUDDir + ViewConfig.HUDHPPath);
            hud.AddHUDOwner(targetEntity.id.Value);
            hud.AddHUDPosition(targetEntity.position.Value.ToUnityVector3());
            hud.AddHUDBindPoint(AvatarBindPointType.Top);
            hud.AddHUDOffset(ViewConfig.HUDHPOffset);
            hud.isHUDAutoDestroyWithOwner = true;
            hud.isHUDPositionSyncWithOwner = true;
            return hud;
        }
    }
}