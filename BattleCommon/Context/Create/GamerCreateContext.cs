//------------------------------------------------------------
//        File:  GamerCreateContext.cs
//       Brief:  GamerCreateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using System.Collections.Generic;
using Battle.Common.Constant;
using Battle.Common.Context.Combat;

namespace Battle.Common.Context.Create
{
    public class GamerCreateContext : CreatureCreateContext
    {
        public int GeneralId;

        public SkillConfData DefSkill;

        public SkillConfData UltSkill;

        public List<SkillConfData> AllSkills;

        public GamerCreateContext() {
            ThingType = ThingType.Gamer;
        }
    }
}