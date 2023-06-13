//------------------------------------------------------------
//        File:  SkillUtil.cs
//       Brief:  SkillUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Logic.Thing.Behaviour.State.Cast;
using Battle.Logic.Thing.Extension;
using SkillModule.Runtime.Skill;

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
            
        }
        
        /// <summary>
        /// 尝试使用指定技能直接施法
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="ability"></param>
        /// <returns></returns>
        private static SkillCastResult TryCastWithAbilityDirectly(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillConfData ability) {

            var context = contexts.GetRefPool<CastStateContext>().Get();
            context.Ability = ability;
            
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