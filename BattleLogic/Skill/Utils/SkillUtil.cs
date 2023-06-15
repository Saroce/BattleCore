//------------------------------------------------------------
//        File:  SkillUtil.cs
//       Brief:  SkillUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using System.Collections.Generic;
using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Behaviour.State.Cast;
using Battle.Logic.Thing.Extension;
using Battle.Logic.Utils;
using Entitas;
using SkillModule.Runtime.Skill;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Skill.Utils
{
    public static class SkillUtil
    {
        /// <summary>
        /// 尝试使用技能施法
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="ability"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static SkillCastResult TryCastWithAbility(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillConfData ability, out ulong target) {
            target = 0ul;
            var error = ValidateCastContext(contexts, thingEntity, ability);
            if (error != SkillCastResult.NoError) {
                return error;
            }

            var baseData = ability.ActiveSkillData.BaseData;
            // 指向目标型技能
            if (baseData.IsDirectional && baseData.DirectionalType == SkillDirectionalType.ToThing) {
                return TaySelectTargetAndCastWithAbility(contexts, thingEntity, ability, out target);
            }

            // 不需要目标，直接施法
            return TryCastWithAbilityDirectly(contexts, thingEntity, ability);
        }

        /// <summary>
        /// 尝试选择目标后施法
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="ability"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static SkillCastResult TaySelectTargetAndCastWithAbility(LogicContexts contexts,
            LogicThingEntity thingEntity, SkillConfData ability, out ulong target) {
            target = 0ul;

            var rangeData = ability.ActiveSkillData.RangeData;
            var rangeExData = ability.ActiveSkillData.RangeExData;
            var selectData = ability.ActiveSkillData.TargetSelectData;

            // 查找，过滤，排序得到目标列表
            var targets = contexts.ListPool<ulong>().Get();
            QueryCreaturesInSkillRange(contexts, thingEntity, rangeData, rangeExData, ref targets);
            SkillTargetSelectUtil.SelectEntities(contexts, thingEntity, selectData, ref targets);

            // 对有效目标尝试施法
            var succeed = false;
            foreach (var targetId in targets) {
                var error = TayCastToTargetWithAbility(contexts, thingEntity, ability, targetId);
                if (error != SkillCastResult.NoError) {
                    continue;
                }

                target = targetId;
                succeed = true;
                break;
            }
            
            contexts.ListPool<ulong>().Return(targets);
            return succeed ? SkillCastResult.NoError : SkillCastResult.NoValidTarget;
        }

        /// <summary>
        /// 对指定目标尝试施法
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="ability"></param>
        /// <param name="targetId"></param>
        /// <returns></returns>
        public static SkillCastResult TayCastToTargetWithAbility(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillConfData ability, ulong targetId) {
            
            // 检验施法状态
            var error = ValidateCastContext(contexts, thingEntity, ability);
            if (error != SkillCastResult.NoError) {
                return error;
            }

            // 目标是否死亡
            var targetEntity = contexts.logicThing.GetEntityWithId(targetId);
            if (targetEntity.isDead || targetEntity.isDestroyed) {
                return SkillCastResult.TargetIsDead;
            }

            // 目标是否在技能范围内
            if (IsTargetTooFar(contexts, thingEntity, targetEntity, ability)) {
                return SkillCastResult.TargetTooFar;
            }

            // 目标是否符合技能选择数据
            if (!SkillTargetSelectUtil.IsTargetSelectDataMatched(contexts, thingEntity, targetEntity,
                    ability.ActiveSkillData.TargetSelectData)) {
                return SkillCastResult.TargetSelectNoMatch;
            }

            var castContext = contexts.RefPool<CastStateContext>().Get();
            castContext.Ability = ability;
            castContext.TargetId = targetId;
            // 切换置施法状态
            if (!thingEntity.Cast(contexts)) {
                return SkillCastResult.CastStateRejected;
            }
            
            return SkillCastResult.NoError;
        }

        private static bool IsTargetTooFar(LogicContexts contexts, LogicThingEntity thingEntity,
            LogicThingEntity targetEntity, SkillConfData ability) {
            return !IsTargetRangeMatched(contexts, thingEntity, targetEntity, ability.ActiveSkillData.RangeData,
                ability.ActiveSkillData.RangeExData);
        }

        private static bool IsTargetRangeMatched(LogicContexts contexts, LogicThingEntity thingEntity,
            LogicThingEntity targetEntity, SkillRangeData rangeData, SkillRangeExData rangeExData) {
            if (!thingEntity.hasPosition || !thingEntity.hasRotation || !targetEntity.hasPosition) {
                return true;
            }

            var originPosition = thingEntity.position.Value;
            var originRotation = thingEntity.rotation.Value;
            var targetPosition = targetEntity.position.Value;
            var targetRadius = targetEntity.hasRadius ? targetEntity.radius.Value : 0f;

            return RangeUtil.IsRangeOverlap(contexts, originPosition, originRotation, targetPosition, targetRadius, rangeData);
        }
        
        /// <summary>
        /// 查询技能范围内的所有生物
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="rangeData"></param>
        /// <param name="rangeExData"></param>
        /// <param name="targets"></param>
        public static void QueryCreaturesInSkillRange(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillRangeData rangeData, SkillRangeExData rangeExData, ref List<ulong> targets) {
            QueryEntitiesInSkillRange(contexts, thingEntity, rangeData, rangeExData, ref targets,
                LogicThingDef.CreatureMatchers);
        }

        /// <summary>
        /// 查询技能范围内的所有实体
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="rangeData"></param>
        /// <param name="rangeExData"></param>
        /// <param name="targets"></param>
        /// <param name="matcher"></param>
        public static void QueryEntitiesInSkillRange(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillRangeData rangeData, SkillRangeExData rangeExData, ref List<ulong> targets,
            IMatcher<LogicThingEntity> matcher = null) {
            var oriPosition = thingEntity.position.Value;
            var oriRotation = thingEntity.rotation.Value;

            matcher = matcher ?? LogicThingDef.CreatureMatchers;
            var ret = contexts.HashSetPool<ulong>().Get();

            // TODO 这里有格子范围判定, 看需不需要

            var entities = contexts.logicThing.GetEntities(matcher);
            foreach (var entity in entities) {
                var radius = (FixedPoint) 0f;
                if (entity.hasRadius) {
                    radius = entity.radius.Value;
                }

                if (RangeUtil.IsRangeOverlap(contexts, oriPosition, oriRotation, entity.position.Value, radius,
                        rangeData)) {
                    ret.Add(entity.id.Value);
                }
            }

            targets.AddRange(ret);
            contexts.HashSetPool<ulong>().Return(ret);
        }

        /// <summary>
        /// 尝试使用指定技能直接施法(不需要选择目标)
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="ability"></param>
        /// <returns></returns>
        private static SkillCastResult TryCastWithAbilityDirectly(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillConfData ability) {
            var context = contexts.RefPool<CastStateContext>().Get();
            context.Ability = ability;
            // 切换置施法状态
            if (!thingEntity.Cast(contexts)) {
                return SkillCastResult.CastStateRejected;
            }

            return SkillCastResult.NoError;
        }

        /// <summary>
        /// 校验施法状态
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="ability"></param>
        /// <returns></returns>
        public static SkillCastResult ValidateCastContext(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillConfData ability) {
            // 被动技能无法施法
            if (ability.IsPassive) {
                return SkillCastResult.PassiveSkillNotCastable;
            }

            if (!thingEntity.IsCastable()) {
                return SkillCastResult.NotCastableState;
            }

            // TODO 其他异常判定，缴械，沉默，冷却, 怒气，充能次数判断

            return SkillCastResult.NoError;
        }
    }
}