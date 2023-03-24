//------------------------------------------------------------
//        File:  SkillSystems.cs
//       Brief:  SkillSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using Battle.Logic.Skill.System;

namespace Battle.Logic.Skill
{
    internal sealed class SkillSystems : Feature
    {
        public SkillSystems(LogicContexts contexts) {
            
            // TearDown System
            Add(new SkillTearDownSystem(contexts));
        }
    }
}
