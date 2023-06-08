//------------------------------------------------------------
//        File:  SkillLevelData.cs
//       Brief:  SkillLevelData
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

namespace Battle.Common.Context.Combat
{
    public class SkillLevelData
    {
        public int Id { get; set; }
        
        public int Level { get; set; }

        public SkillLevelData(int id) {
            Id = id;
            Level = 1;
        }
        
        public SkillLevelData(int id, int level) {
            Id = id;
            Level = level;
        }
    }
}