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
using Core.Lite.RefPool.Builtin;
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
        /// 尝试选择目标后释放
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

            var targets = contexts.ListPool<ulong>().Get();
            QueryCreaturesInSkillRange(contexts, thingEntity, rangeData, rangeExData, ref targets);
            SkillTargetSelectUtil.SelectEntities(contexts, thingEntity, selectData, ref targets);
        }

        public static void QueryCreaturesInSkillRange(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillRangeData rangeData, SkillRangeExData rangeExData, ref List<ulong> targets) {
            QueryEntitiesInSkillRange(contexts, thingEntity, rangeData, rangeExData, ref targets, LogicThingDef.CreatureMatchers);
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
                var radius = (FixedPoint)0f;
                if (entity.hasRadius) {
                    radius = entity.radius.Value;
                }

                if (RangeUtil.IsRangeOverlap(contexts, oriPosition, oriRotation, entity.position.Value, radius, rangeData)) {
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

            var context = contexts.GetRefPool<CastStateContext>().Get();
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
            
            // TODO 其他异常判定，缴械，沉默，冷却等

            return SkillCastResult.NoError;
        }
    }
}