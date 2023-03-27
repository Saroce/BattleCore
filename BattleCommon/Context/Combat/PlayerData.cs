//------------------------------------------------------------
//        File:  PlayerData.cs
//       Brief:  PlayerData
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

namespace Battle.Common.Context.Combat
{
    public class PlayerData
    {
        public long UId { get; set; }
        
        public int HeroId { get; set; }
        
        public bool IsOther { get; set; }
        
        public CombatValue CombatValue { get; set; }
        
        public SkillData DefaultSkillData { get; set; }
        
        public SkillData UltimateSkillData { get; set; }
    }
}