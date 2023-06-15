//------------------------------------------------------------
//        File:  SkillEx.cs
//       Brief:  SkillEx
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Thing.Extension;

namespace Battle.Logic.Skill
{
    internal static class SkillEx
    {
        public static void CastSkill(this LogicSkillContext context, LogicContexts contexts, LogicThingEntity caster,
            ulong targetId, SkillConfData ability) {
            var castSpeed = caster.GetCastSpeedScale(contexts, ability);

            var skillEntity = context.CreateEntity();
            skillEntity.AddId(contexts.GetIndependentId());
            skillEntity.AddSkillCasterId(caster.id.Value);
            skillEntity.AddSkillTargetId(targetId);
            skillEntity.AddSkillCastContext(caster.id.Value, targetId, ability, castSpeed);
        }
    }
}