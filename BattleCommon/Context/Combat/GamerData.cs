//------------------------------------------------------------
//        File:  Gamer.cs
//       Brief:  Gamer
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using vFrame.Lockstep.Core;

namespace Battle.Common.Context.Combat
{
    public class GamerData
    {
        public ulong Id { get; set; }
        
        public int GeneralId { get; set; }
        
        public bool IsOther { get; set; }
        
        public CombatValue CombatValue { get; set; }
        
        public SkillData DefaultSkillData { get; set; }
        
        public SkillData UltimateSkillData { get; set; }
        
        public TSVector Position { get; set; }
        
        public TSQuaternion Rotation { get; set; }
    }
}