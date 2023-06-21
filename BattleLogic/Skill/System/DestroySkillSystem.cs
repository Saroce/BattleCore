//------------------------------------------------------------
//        File:  DestroySkillSystem.cs
//       Brief:  DestroySkillSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.System;
using Entitas;

namespace Battle.Logic.Skill.System
{
    internal class DestroySkillSystem : LogicBaseSystem, ICleanupSystem, ITearDownSystem
    {
        private static readonly IMatcher<LogicSkillEntity> SkillMatcher = LogicSkillMatcher.Destroyed;

        private readonly IGroup<LogicSkillEntity> _group;
        
        public DestroySkillSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicSkill.GetGroup(SkillMatcher);
        }

        public void Cleanup() {
            foreach (var skillEntity in _group.GetEntities()) {
                skillEntity.Destroy();
            }
        }

        public void TearDown() {
            foreach (var skillEntity in Contexts.logicSkill.GetEntities()) {
                skillEntity.Destroy();
            }
        }
    }
}