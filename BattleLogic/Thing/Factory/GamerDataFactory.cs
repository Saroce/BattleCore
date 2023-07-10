//------------------------------------------------------------
//        File:  GamerDataFactory.cs
//       Brief:  GamerDataFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Combat;
using Battle.Common.Context.GamerGroup;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Extension;
using Battle.Logic.Utils;

namespace Battle.Logic.Thing.Factory
{
    internal static class GamerDataFactory
    {
        /// <summary>
        /// 创建玩家数据实体
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="gamerData"></param>
        /// <returns>玩家Id</returns>
        public static ulong CreateGamerData(this LogicContexts contexts, GamerData gamerData) {
            var entity = contexts.logicThing.CreateEntity();
            
            entity.AddId(contexts.GetIndependentId());
            entity.AddGamerInfo(gamerData);
            entity.AddGamerGeneralId(gamerData.GeneralId);
            entity.AddGamerCombat(gamerData.CombatValue);
            entity.SetPropertiesFromCombatValue(gamerData.CombatValue);
            
            // 技能数据
            var skills = new List<SkillConfData>();
            var ultId = string.Empty;
            var defId = string.Empty;

            foreach (var skillLevelData in gamerData.AllSkillDataList) {
                var skillConfData = ConfigUtil.ReadSkillConfData(contexts, skillLevelData.Id, skillLevelData.Level);
                // 记录下默认技能数据的guid
                if (skillConfData.Id == gamerData.DefaultSkillData.Id) {
                    defId = skillConfData.Guid;
                }
                // 记录下奥义技能数据guid
                if (skillConfData.Id == gamerData.UltimateSkillData.Id) {
                    ultId = skillConfData.Guid;
                }
                
                skills.Add(skillConfData);
            }

            if (!string.IsNullOrEmpty(defId)) {
                entity.AddGamerDefSkill(defId);
            }

            if (!string.IsNullOrEmpty(ultId)) {
                entity.AddGamerUltSkill(ultId);
            }

            if (skills.Count > 0) {
                entity.AddGamerSkills(skills);
            }

            var passiveAbilities = skills.FindAll(v => v.IsPassive);
            if (passiveAbilities.Count > 0) {
                entity.AddPassiveAbilities(passiveAbilities);
            }
            
            contexts.LogDebug(LogTagDef.ThingLogTag, "Create gamer, entity id: {0}, general id: {1}",
                entity.id.Value, entity.gamerGeneralId.Value);
            
            entity.isThing = entity.isGamerData = true;
            return entity.id.Value;
        }
    }
}