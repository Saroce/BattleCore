//------------------------------------------------------------
//        File:  ThingSkillEx.cs
//       Brief:  ThingSkillEx
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Combat;

namespace Battle.Logic.Thing.Extension
{
    public static class ThingSkillEx
    {
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
    }
}