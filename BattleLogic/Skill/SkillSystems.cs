﻿//------------------------------------------------------------
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
            
            // Reactive Systems
            Add(new CastSkillSystem(contexts));
            
            // Execute Systems
            Add(new ProcessSkillFluxEventSystem(contexts));
            
            // TearDown System
            Add(new SkillTearDownSystem(contexts));
        }
    }
}
