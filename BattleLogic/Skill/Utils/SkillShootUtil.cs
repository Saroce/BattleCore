//------------------------------------------------------------
//        File:  SkillShootUtil.cs
//       Brief:  SkillShootUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-11
//============================================================

using System;
using System.Collections.Generic;
using Battle.Common.Constant;
using Battle.Common.Context.Create;
using Battle.Logic.Constant;
using Battle.Logic.Skill.Component.Flux;
using Battle.Logic.Thing.Factory;
using Core.Lockstep.Math;
using SkillModule.Runtime.Skill;

namespace Battle.Logic.Skill.Utils
{
    public static class SkillShootUtil
    {
        public static void ProcessShoot(LogicContexts contexts, ulong casterId, ulong targetId,
            ShootFluxEventContext shootEvent) {
            var caster = contexts.logicThing.GetEntityWithId(casterId);
            if (null == caster) {
                contexts.LogWarning(LogTagDef.SkillLogTag, "Process shoot event, but caster not found: {0}", casterId);
                return;
            }

            contexts.LogDebug(LogTagDef.SkillLogTag,
                "Process shoot event, casterId: {0}, skill guid: {1}, shootId: {2}",
                casterId, shootEvent.SkillConfData.Guid, shootEvent.ShootData.Guid);

            var skillData = shootEvent.SkillConfData.ActiveSkillData;
            
            // 非指向性技能
            if (!skillData.BaseData.IsDirectional) {
                ProcessNonDirectionShoot(contexts, caster, shootEvent);
                return;
            }
            
            // 指向性技能
            switch (skillData.BaseData.DirectionalType) {
                // 对人逻辑处理
                case SkillDirectionalType.ToThing: {
                    if (targetId == 0) {
                        contexts.LogError(LogTagDef.SkillLogTag, "Process shoot event DirectionalType == ToThing but targetId == 0");
                        return;
                    }

                    var target = contexts.logicThing.GetEntityWithId(targetId);
                    if (target == null) {
                        return;
                    }
                    ProcessDirectionalShootToThing(contexts, caster, target, shootEvent);
                    break;
                }
                // 对地逻辑处理
                case SkillDirectionalType.ToGround:
                    // TODO 
                    break;
            }
        }

        private static void ProcessNonDirectionShoot(LogicContexts contexts, LogicThingEntity caster,
            ShootFluxEventContext shootEvent) {
            // TODO 非指向性技能处理
        }

        /// <summary>
        /// 指向性(对人)技能逻辑处理
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="caster"></param>
        /// <param name="target"></param>
        /// <param name="shootEvent"></param>
        private static void ProcessDirectionalShootToThing(
            LogicContexts contexts, 
            LogicThingEntity caster, 
            LogicThingEntity target, 
            ShootFluxEventContext shootEvent) {

            var targets = contexts.ListPool<ulong>().Get();
            
            // 收集生效目标
            CollectShootTargets(contexts, caster, target, shootEvent, ref targets);

            foreach (var targetId in targets) {
                var bulletEntity = CreateThingBullet(contexts, caster, targetId, shootEvent, TSVector.MinValue);
                if (bulletEntity == null) {
                    continue;
                }
                
                
            }
        }

        private static LogicThingEntity CreateThingBullet(
            LogicContexts contexts, 
            LogicThingEntity caster, 
            ulong targetId, 
            ShootFluxEventContext shootEvent, 
            TSVector destPosition) {

            if (destPosition == TSVector.MinValue) {
                destPosition = GetBulletAppearPosition(contexts, caster, targetId, shootEvent);
            }

            var createContext = new BulletCreateContext() {
                ShootData = shootEvent.FluxShootData,
                CampFlag = caster.camp.Value,
                Position = destPosition,
            };

            var bulletEntity = contexts.CreateThing(createContext);
            
        }

        /// <summary>
        /// 获取子弹出现的位置
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="caster"></param>
        /// <param name="targetId"></param>
        /// <param name="shootData"></param>
        /// <returns></returns>
        private static TSVector GetBulletAppearPosition(
            LogicContexts contexts,
            LogicThingEntity caster,
            ulong targetId,
            ShootFluxEventContext shootData) {

            var position = TSVector.MinValue;
            switch ((ShootReferenceType) shootData.FluxShootData.ReferenceType) {
                case ShootReferenceType.Owner:
                    position = caster.hasPosition ? caster.position.Value : position;
                    break;
                case ShootReferenceType.Target: {
                    var target = contexts.logicThing.GetEntityWithId(targetId);
                    if (target != null) {
                        position = target.hasPosition ? target.position.Value : position;
                    }
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // 返回相对位置 + 偏移
            return position == TSVector.MinValue ? position : position + shootData.FluxShootData.TSOffset;
        }
        
        private static void CollectShootTargets(
            LogicContexts contexts,
            LogicThingEntity caster,
            LogicThingEntity target,
            ShootFluxEventContext shootEvent,
            ref List<ulong> targets) {
            
            // 锁定目标生效
            targets.Add(target.id.Value);
            
            // 多目标支持
            var shootData = shootEvent.ShootData;
            var skillData = shootEvent.SkillConfData.ActiveSkillData;
            if (!shootData.MultipleTarget) {
                return;
            }
            
            // TODO 多目标筛选
        }
    }
}