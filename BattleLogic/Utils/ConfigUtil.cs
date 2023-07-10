//------------------------------------------------------------
//        File:  ConfigUtil.cs
//       Brief:  ConfigUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

using System;
using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Logic.Constant;
using ExcelConvert.Auto.SkillConf;
using Google.Protobuf;
using SkillModule.Runtime.Skill;

namespace Battle.Logic.Utils
{
    internal static class ConfigUtil
    {
        public static SkillConfData ReadSkillConfData(LogicContexts contexts, int skillId, int level = 1) {
            var configReader = contexts.GetConfigReader();

            var levelConf = configReader.GetRecord<SkillConf_SkillLevel_Record>("SkillId", skillId, "SkillLevel", level);
            var skillData = ReadSkillData(contexts, levelConf.SkillConfPath);
            try {
                // TODO 暂时未配置技能等级数据
                var data = (SkillConfData)skillData?.GetSkillData();
                data.Id = skillId;
                data.Level = level;
                return data;
            }
            catch (Exception e) {
                contexts.LogError(LogTagDef.ThingLogTag, "Get skill data failed, skill id:{0}, level:{1}, guid:{2}",
                    skillId, level, skillData?.Guid ?? string.Empty);
                throw;
            }
        }

        private static SkillData ReadSkillData(LogicContexts contexts, string path) {
            var dataReader = contexts.GetDataReader();
            var skillData = dataReader.ReadData<SkillData>(SkillDef.SkillDataDir + path);
            if (skillData == null) {
                contexts.LogError(LogTagDef.SkillLogTag, "Skill conf data read failed: {0}", path);
                return null;
            }

            return skillData;
        }

        /// <summary>
        /// 从配置表中读取数据
        /// </summary>
        /// <param name="conf"></param>
        /// <returns></returns>
        public static CombatValue ReadCombatValue(IMessage conf) {
            var combatValue = new CombatValue {
                HpCur = conf.GetPropertyValue("HP"),
                HpMax = conf.GetPropertyValue("HP"),
                Attack = conf.GetPropertyValue("Attack"),
                PhysicsDefend = conf.GetPropertyValue("PhysicsDefend"),
                MagicDefend = conf.GetPropertyValue("MagicDefend"),
                HitRate = conf.GetPropertyValue("HitRate"),
                DodgeRate = conf.GetPropertyValue("DodgeRate"),
                CriticalRate = conf.GetPropertyValue("Crit"),
                MoveSpeed = conf.GetPropertyValue("MoveSpeed"),
                CastSpeed = conf.GetPropertyValue("CastSpeed"),
            };
            return combatValue;
        }

        private static int GetPropertyValue(this IMessage message, string propName) {
            var type = message.GetType();
            var propInfo = type.GetProperty(propName);
            if (propInfo == null) {
                throw new ArgumentNullException($"property not found, name:{propName}, type:{type.FullName}");
            }
            return (int)propInfo.GetValue(message, null);
        }
    }
}