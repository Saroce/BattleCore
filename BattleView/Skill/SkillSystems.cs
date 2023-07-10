//------------------------------------------------------------
//        File:  SkillSystems.cs
//       Brief:  SkillSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.View.Skill.System;

namespace Battle.View.Skill
{
    internal sealed class SkillSystems : Feature 
    {
        public SkillSystems(ViewContexts contexts) {
            
            // Reactive Systems
            Add(new AddSkillCastViewSystem(contexts));
            Add(new AddSkillHitViewSystem(contexts));
            
            // Clean up
            Add(new DestroySkillViewSystem(contexts));
        }
    }
}