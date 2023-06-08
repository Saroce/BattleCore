//------------------------------------------------------------
//        File:  Gamer.cs
//       Brief:  Gamer
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Combat;
using vFrame.Lockstep.Core;

namespace Battle.Common.Context.GamerGroup
{
    public class GamerData
    {
        public bool IsOther { get; set; }
        
        public CombatValue CombatValue { get; set; }
        
        public SkillLevelData DefaultSkillData { get; set; }
        
        public SkillLevelData UltimateSkillData { get; set; }

        public List<SkillLevelData> AllSkillDataList { get; set; } = new List<SkillLevelData>();

        public int GeneralId { get; set; }
        
        public TSVector Position { get; set; }
        
        public TSQuaternion Rotation { get; set; }
    }
}