//------------------------------------------------------------
//        File:  OnEffectPropModify.cs
//       Brief:  处理效果属性变化消息，主要用于显示属性变化的飘字
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using System;
using Battle.Common.Constant;
using Battle.Common.Context.Message.Effect;
using Battle.View.Constant;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.View.Input.System.Processor
{
    internal class OnEffectPropModify : MessageProcessor<EffectPropModificationMessage>
    {
        protected override void OnProcess(EffectPropModificationMessage message) {
            switch (message.Source) {
                case EffectSource.Skill:
                    OnSkillEffectPropModified(message);
                    break;
                case EffectSource.Buff:
                    // TODO 
                    break;
            }
        }

        private void OnSkillEffectPropModified(EffectPropModificationMessage message) {
            var skillConfData = message.UserData.SkillConfData;
            if (skillConfData?.ActiveSkillData == null) {
                return;
            }

            // 技能配置不显示飘字
            if (!skillConfData.ActiveSkillData.BaseData.ShowValue) {
                return;
            }
            
            ShowHpValue(message);
        }

        private void ShowHpValue(EffectPropModificationMessage message) {
            if (message.PropertyType != (int)ThingPropertyType.HpCur) {
                return;
            }

            var targetEntity = Contexts.viewThing.GetEntityWithId(message.TargetId);
            if (targetEntity == null || !targetEntity.hasAvatarView) {
                return;
            }

            var viewConfig = Contexts.GetController().GetViewConfig();
            var randomPos = new Vector3(
                Random.Range(-viewConfig.HUDDamageRandomX, viewConfig.HUDDamageRandomX),
                Random.Range(0f, viewConfig.HUDDamageRandomY),
                0f);

            string hudPath;
            if (message.DeltaValue > 0) {
                hudPath = viewConfig.HUDHealPath;
            }
            else {
                // TODO 区分不同类型伤害，暴击伤害飘字
                hudPath = viewConfig.HUDDamagePath;
            }

            if (string.IsNullOrEmpty(hudPath)) {
                return;
            }
            
            // 创建飘字HUD
            var hudEntity = Contexts.viewHUD.CreateEntity();
            hudEntity.AddHUDAsset(viewConfig.HUDDir + hudPath);
            hudEntity.AddHUDOwner(message.TargetId);
            hudEntity.AddHUDPosition(targetEntity.avatarView.Container.transform.position);
            hudEntity.AddHUDBindPoint(AvatarBindPointType.Top);
            hudEntity.AddHUDOffset(viewConfig.HUDDamageOffset + randomPos);
            hudEntity.AddHUDDamageValue((int) message.DeltaValue);
            hudEntity.isHUDAutoDestroyWhenPlayFinished = true;
        }
    }
}