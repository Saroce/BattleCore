//------------------------------------------------------------
//        File:  SkillTargetSelectUtil.cs
//       Brief:  SkillTargetSelectUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-14
//============================================================

using System.Collections.Generic;
using Battle.Logic.Skill.Comparer;
using Core.Lockstep.Math;
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

            // if (selectData.TargetSelectCampType != SkillTargetSelectCampType.Self) {
            //     // TODO 通过职业筛选
            // }
            //
            // // TODO 根据过滤信息过滤
            
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
            if (!thingEntity.hasCamp) {
                return;
            }

            var toRemoved = contexts.ListPool<ulong>().Get();
            foreach (var targetId in targets) {
                var targetEntity = contexts.logicThing.GetEntityWithId(targetId);
                if (targetEntity == null) {
                    continue;
                }

                if (!IsTargetCampMatched(contexts, thingEntity, targetEntity, campType)) {
                    toRemoved.Add(targetEntity.id.Value);
                }
            }

            foreach (var id in toRemoved) {
                targets.Remove(id);
            }
            
            contexts.ListPool<ulong>().Return(toRemoved);
        }

        /// <summary>
        /// 目标阵营是否符合
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="targetEntity"></param>
        /// <param name="campType"></param>
        /// <returns></returns>
        public static bool IsTargetCampMatched(LogicContexts contexts, LogicThingEntity thingEntity,
            LogicThingEntity targetEntity, SkillTargetSelectCampType campType) {
            if (campType == SkillTargetSelectCampType.None) {
                return true;
            }

            if (!thingEntity.hasCamp || !targetEntity.hasCamp) {
                return false;
            }

            var ret = false;
            // 自身
            if ((campType & SkillTargetSelectCampType.Self) > 0) {
                ret |= thingEntity == targetEntity;
            }

            // 敌方
            if ((campType & SkillTargetSelectCampType.Enemy) > 0) {
                ret |= thingEntity != targetEntity && ((int)thingEntity.camp.Value & (int)targetEntity.camp.Value) == 0;
            }

            // 友方
            if ((campType & SkillTargetSelectCampType.Friend) > 0) {
                ret |= thingEntity != targetEntity && ((int)thingEntity.camp.Value & (int)targetEntity.camp.Value) > 0;
            }

            return ret;
        }
        
        public static void SortEntities(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillTargetSelectData selectData, ref List<ulong> targets) {
            if (targets.Count <= 1) {
                return;
            }

            var nestedComparer = contexts.RefPool<NestedComparer>().Get();
            nestedComparer.Create(contexts);

            // 优先血量少的
            if ((selectData.TargetSelectPreferType & SkillTargetSelectPreferType.LessHealthPoint) > 0) {
                var comparer = contexts.RefPool<LessHealthPointComparer>().Get();
                comparer.Create(contexts.logicThing);
                nestedComparer.AddComparer(comparer);
            }
            
            // 优先距离近的
            if ((selectData.TargetSelectPreferType & SkillTargetSelectPreferType.Nearby) > 0) {
                var comparer = contexts.RefPool<DistanceComparer>().Get();
                comparer.Create(contexts.logicThing, thingEntity);
                nestedComparer.AddComparer(comparer);
            }
            
            targets.Sort(nestedComparer);
            nestedComparer.Destroy();
            contexts.RefPool<NestedComparer>().Return(nestedComparer);
        }

        /// <summary>
        /// 技能目标选择数据是否符合
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="target"></param>
        /// <param name="selectData"></param>
        /// <returns></returns>
        public static bool IsTargetSelectDataMatched(LogicContexts contexts, LogicThingEntity thingEntity,
            LogicThingEntity target, SkillTargetSelectData selectData) {
            // TODO 比较阵营，职业，排除选项

            return true;
        }

        public static bool TestRandom(LogicContexts contexts, FixedPoint value) {
            var randomValue = contexts.GetRandom().Next01() * 100f;
            return randomValue <= value;
        }
    }
}