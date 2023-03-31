//------------------------------------------------------------
//        File:  SkillTearDownSystem.cs
//       Brief:  SkillTearDownSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using Battle.Logic.Base.System;

namespace Battle.Logic.Skill.System
{
    internal class SkillTearDownSystem : LogicTearDownSystem
    {
        public SkillTearDownSystem(LogicContexts contexts) : base(contexts) {
        }

        public override void TearDown() {
            foreach (var skillEntity in Contexts.logicSkill.GetEntities()) {
                skillEntity.Destroy();
            }
        }
    }
}
