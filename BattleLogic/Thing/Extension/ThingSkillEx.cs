//------------------------------------------------------------
//        File:  ThingSkillEx.cs
//       Brief:  ThingSkillEx
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

using System;
using System.Collections.Generic;
using Battle.Common.Context.Combat;
using Core.Lite.Base;

namespace Battle.Logic.Thing.Extension
{
    public static class ThingSkillEx
    {
        public static bool IsDefSkill(this LogicThingEntity thingEntity, SkillConfData skillConfData) {
            if (!thingEntity.hasDefaultCastAbility) {
                return false;
            }

            return thingEntity.defaultCastAbility.Value.Guid == skillConfData.Guid;
        }

        public static bool IsUltSkill(this LogicThingEntity thingEntity, SkillConfData skillConfData) {
            if (!thingEntity.hasUltimateAbility) {
                return false;
            }

            return thingEntity.ultimateAbility.Value.Guid == skillConfData.Guid;
        }

        public static SkillConfData GetGamerDefSkill(this LogicThingEntity thingEntity) {
            if (!thingEntity.hasGamerDefSkill || !thingEntity.hasGamerSkills) {
                return null;
            }

            var defId = thingEntity.gamerDefSkill.Value;
            var skills = thingEntity.gamerSkills.Value;
            foreach (var skill in skills) {
                if (skill.Guid == defId) {
                    return skill;
                }
            }

            return null;
        }
        
        public static SkillConfData GetGamerUltSkill(this LogicThingEntity thingEntity) {
            if (!thingEntity.hasGamerUltSkill || !thingEntity.hasGamerSkills) {
                return null;
            }

            var ultId = thingEntity.gamerUltSkill.Value;
            var skills = thingEntity.gamerSkills.Value;
            foreach (var skill in skills) {
                if (skill.Guid == ultId) {
                    return skill;
                }
            }

            return null;
        }

        public static List<SkillConfData> GetGamerAllSkills(this LogicThingEntity thingEntity) {
            return thingEntity.hasGamerSkills ? thingEntity.gamerSkills.Value : null;
        }
        
        public static void ReadSkillAbilities(this LogicContexts contexts, LogicThingEntity thingEntity,
            SkillConfData defSkill, SkillConfData ultSkill, params SkillConfData[] allSkills) {

            // 默认技能
            if (defSkill != null) {
                thingEntity.AddDefaultCastAbility(defSkill);
            }

            // 奥义技能
            if (ultSkill != null) {
                thingEntity.AddUltimateAbility(ultSkill);
                // TODO 非被动奥义型技能，怒气，充能TODO
            }
            
            // 所有技能
            var castAbilities = contexts.ListPool<SkillConfData>().Get();
            var passiveAbilities = contexts.ListPool<SkillConfData>().Get();
            foreach (var skill in allSkills) {
                if (skill.IsPassive) {
                    passiveAbilities.Add(skill);
                }
                else {
                    castAbilities.Add(skill);
                }
            }

            var comparer = contexts.RefPool<CastAbilityComparer>().Get();
            comparer.Create(thingEntity);
            castAbilities.Sort(comparer);
            contexts.RefPool<CastAbilityComparer>().Return(comparer);
            
            thingEntity.AddCastAbilities(castAbilities);
            thingEntity.AddPassiveAbilities(passiveAbilities);
        }
    }
    
    /// <summary>
    /// 释放能力比较器：将默认释放排在后面
    /// </summary>
    internal class CastAbilityComparer : BaseObject<LogicThingEntity>, IComparer<SkillConfData>
    {
        private LogicThingEntity _thingEntity;
        
        protected override void OnDestroy() {
            _thingEntity = null;
        }

        protected override void OnCreate(LogicThingEntity arg1) {
            _thingEntity = arg1;
        }
        
        public int Compare(SkillConfData x, SkillConfData y) {
            if (x == null) {
                return 1;
            }

            if (y == null) {
                return -1;
            }

            if (_thingEntity.IsDefSkill(x) && _thingEntity.IsDefSkill(y)) {
                return string.Compare(x.Guid, y.Guid, StringComparison.Ordinal);
            }

            if (_thingEntity.IsDefSkill(x)) {
                return 1;
            }

            return -1;
        }
    }
}