﻿//------------------------------------------------------------
//        File:  SkillJudgeUtil.cs
//       Brief:  SkillJudgeUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using System;
using System.Collections.Generic;
using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Common.Context.Message.Skill;
using Battle.Logic.Constant;
using Battle.Logic.Effect;
using Battle.Logic.Skill.Component.Flux;
using Battle.Logic.Utils;
using Core.Lockstep.Math;
using SkillModule.Runtime.Skill;

namespace Battle.Logic.Skill.Utils
{
    internal static class SkillJudgeUtil
    {
        public static void ProcessJudge(LogicContexts contexts, ulong casterId, ulong targetId,
            JudgeFluxEventContext fluxEvent) {
            var caster = contexts.logicThing.GetEntityWithId(casterId);
            if (null == caster) {
                contexts.LogWarning(LogTagDef.SkillLogTag, "Process judge event, but caster not found: {0}", casterId);
                return;
            }

            contexts.LogDebug(LogTagDef.SkillLogTag,
                "Process judge event, casterId: {0}, skill guid: {1}, judgeId: {2}",
                casterId, fluxEvent.SkillConfData.Guid, fluxEvent.JudgeData.Guid);

            // 处理技能判定效果
            foreach (var effectData in fluxEvent.JudgeData.EffectDataList) {
                var hitTargets = new List<ulong>();
                var userData = BuildEffectUserData(contexts, fluxEvent, casterId, fluxEvent.SkillEntityId);

                switch (effectData.JudgeType) {
                    case SkillJudgeType.None:
                        contexts.AddEffect(casterId, 0ul, effectData.EffectData, true, EffectSource.Skill,
                            userData);
                        break;
                    case SkillJudgeType.Single: {
                        if (targetId > 0 && SkillTargetSelectUtil.TestRandom(contexts, effectData.Probability)) {
                            contexts.AddEffect(casterId, targetId, effectData.EffectData, true, EffectSource.Skill,
                                userData);
                            hitTargets.Add(targetId);
                        }
                        break;
                    }
                    case SkillJudgeType.Range:
                    case SkillJudgeType.All: {
                        var realTargets = contexts.ListPool<ulong>().Get();
                        // 收集受影响的目标
                        CollectAffectedTargets(contexts, fluxEvent, effectData, casterId, targetId, ref realTargets);
                        // 对多个物体添加效果
                        contexts.AddEffects(casterId, realTargets, effectData.EffectData, true, EffectSource.Skill, userData);
                        // 记录命中目标
                        foreach (var realTarget in realTargets) {
                            if (hitTargets.IndexOf(realTarget) < 0) {
                                hitTargets.Add(realTarget);
                            }
                        }
                        
                        contexts.ListPool<ulong>().Return(realTargets);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                // 向外部发送技能判定命中消息
                var judgeHitMessage = contexts.RefPool<SkillJudgeHitMessage>().Get();
                judgeHitMessage.CasterId = casterId;
                judgeHitMessage.Targets = hitTargets;
                judgeHitMessage.SkillConfData = fluxEvent.SkillConfData;
                judgeHitMessage.EffectData = effectData;
                contexts.SendMessage(judgeHitMessage);
            }
        }

        private static EffectUserData BuildEffectUserData(LogicContexts contexts,
            SkillFluxEventContext fluxEventContext, ulong casterId, ulong skillEntityId) {
            var skillData = fluxEventContext.SkillConfData.ActiveSkillData;
            var userData = new EffectUserData() {
                SkillConfData = fluxEventContext.SkillConfData,
                SkillCasterId = casterId,
                SkillEntityId = skillEntityId,
                Duration = (FixedPoint)skillData.BaseData.Duration / 1000f
            };

            return userData;
        }

        private static void CollectAffectedTargets(LogicContexts contexts,
            SkillFluxEventContext fluxEventContext,
            ActiveSkillEffectData effectData,
            ulong casterId,
            ulong targetId,
            ref List<ulong> realTargets) {
            
            var caster = contexts.logicThing.GetEntityWithId(casterId);
            if (null == caster) {
                return;
            }
            
            // 根据判定类型收集目标
            CollectTargetByJudgeType(contexts, caster, targetId, effectData, fluxEventContext, ref realTargets);
            
            // 选择有效目标
            SkillTargetSelectUtil.SelectEntities(contexts, caster, effectData.TargetSelectData, ref realTargets);
            
            // 生效数量限制
            SkillTargetSelectUtil.TrimAffectCount(effectData.TargetAffectMaxCount, ref realTargets);
            
            // 生效概率限制
            SkillTargetSelectUtil.TrimAffectCountByRandom(contexts, effectData.Probability, effectData.TargetAffectMinCount, ref realTargets);
        }

        private static void CollectTargetByJudgeType(LogicContexts contexts,
            LogicThingEntity caster,
            ulong targetId,
            ActiveSkillEffectData effectData,
            SkillFluxEventContext fluxEventContext,
            ref List<ulong> targets) {

            switch (effectData.JudgeType) {
                case SkillJudgeType.Range: {
                    var target = contexts.logicThing.GetEntityWithId(targetId);
                    if (target == null) {
                        return;
                    }

                    var radius = (FixedPoint)effectData.JudgeRadius / 100f;
                    ThingQueryUtil.QueryEntitiesAround(contexts, target, radius, ref targets);
                    break;
                }
                case SkillJudgeType.All: {
                    var rangeData = fluxEventContext.SkillConfData.ActiveSkillData.RangeData;
                    ThingQueryUtil.QueryEntitiesInRange(contexts, caster, rangeData, effectData.RangeExData, ref targets);
                    break;
                }
            }
        }
    }
}