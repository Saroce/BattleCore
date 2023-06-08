//------------------------------------------------------------
//        File:  SkillConfData.cs
//       Brief:  SkillConfData
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

using SkillModule.Runtime.Skill;

namespace Battle.Common.Context.Combat
{
    public class SkillConfData
    {
        /// <summary>
        /// 技能数据
        /// </summary>
        public ActiveOrPassiveSkillData RawSkillData { get; set; }
        
        /// <summary>
        /// 主动技能数据
        /// </summary>
        public ActiveSkillData ActiveSkillData => RawSkillData as ActiveSkillData;
        
        /// <summary>
        /// 被动技能数据
        /// </summary>
        public PassiveSkillData PassiveSkillData => RawSkillData as PassiveSkillData;

        public bool IsPassive => RawSkillData is PassiveSkillData;

        /// <summary>
        /// 技能数据GUID
        /// </summary>
        public string Guid => RawSkillData.Guid;

        public int Id { get; set; }
        
        public int Level { get; set; }
        
        public static implicit operator SkillConfData(ActiveOrPassiveSkillData skillData) {
            return new SkillConfData() {
                RawSkillData = skillData
            };
        }

        public static implicit operator SkillLevelData(SkillConfData skillConfData) {
            return skillConfData == null ? null : new SkillLevelData(skillConfData.Id, skillConfData.Level);
        }
    }
}