//------------------------------------------------------------
//        File:  DestroySkillOnFinishSystem.cs
//       Brief:  DestroySkillOnFinishSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using System.Collections.Generic;
using Battle.Logic.Base.System;
using Entitas;

namespace Battle.Logic.Skill.System
{
    internal class DestroySkillOnFinishSystem : LogicReactiveSystem<LogicSkillEntity>
    {
        private static readonly IMatcher<LogicSkillEntity> SkillMatcher = LogicSkillMatcher.SkillFinished;

        public DestroySkillOnFinishSystem(LogicContexts contexts) : base(contexts, contexts.logicSkill) {
            
        }

        protected override ICollector<LogicSkillEntity> GetTrigger(IContext<LogicSkillEntity> context) {
            return context.CreateCollector(SkillMatcher);
        }

        protected override bool Filter(LogicSkillEntity entity) {
            return entity.isSkillFinished && entity.hasSkillCastContext;
        }

        protected override void Execute(List<LogicSkillEntity> entities) {
            foreach (var skillEntity in entities) {
                skillEntity.Destroy();
            }
        }
    }
}