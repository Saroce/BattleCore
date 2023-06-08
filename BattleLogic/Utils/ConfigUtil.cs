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
                var data = (SkillConfData)skillData.GetSkillData();
                data.Id = skillId;
                data.Level = level;
                return data;
            }
            catch (Exception e) {
                Console.WriteLine(e);
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
    }
}