//------------------------------------------------------------
//        File:  SkillTargetSelectUtil.cs
//       Brief:  SkillTargetSelectUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-14
//============================================================

using System.Collections.Generic;
using SkillModule.Runtime.Skill;

namespace Battle.Logic.Skill.Utils
{
    public static class SkillTargetSelectUtil
    {
        /// <summary>
        /// 根据技能编辑器的输入规则选择有效的实体
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="caster"></param>
        /// <param name="selectData"></param>
        /// <param name="targets"></param>
        public static void SelectEntities(LogicContexts contexts, LogicThingEntity caster,
            SkillTargetSelectData selectData, ref List<ulong> targets) {
            // 根据阵营选择目标
            SelectEntitiesByCampType(contexts, caster, selectData.TargetSelectCampType, ref targets);

            if (selectData.TargetSelectCampType != SkillTargetSelectCampType.Self) {
                // TODO 通过职业筛选
            }
            
            // TODO 根据过滤信息过滤
            
            // 根据排序规则对目标排序
            SortEntities(contexts, caster, selectData, ref targets);
        }

        /// <summary>
        /// 根据阵营标记选择有效实体
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="campType"></param>
        /// <param name="targets"></param>
        public static void SelectEntitiesByCampType(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillTargetSelectCampType campType, ref List<ulong> targets) {
            // TODO    
        }

        public static void SortEntities(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillTargetSelectData selectData, ref List<ulong> targets) {
            if (targets.Count <= 1) {
                return;
            }
            
            // TODO 排序规则
        }
    }
}