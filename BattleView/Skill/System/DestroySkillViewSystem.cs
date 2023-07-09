//------------------------------------------------------------
//        File:  DestroySkillViewSystem.cs
//       Brief:  DestroySkillViewSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-09
//============================================================

using Battle.View.Base.System;
using Battle.View.Constant;
using Entitas;

namespace Battle.View.Skill.System
{
    internal class DestroySkillViewSystem : ViewBaseSystem, ICleanupSystem, ITearDownSystem
    {
        private readonly IGroup<ViewSkillEntity> _group;
        public DestroySkillViewSystem(ViewContexts contexts) : base(contexts) {
            _group = contexts.viewSkill.GetGroup(ViewSkillMatcher.Destroyed);
        }

        public void Cleanup() {
            foreach (var skillEntity in _group.GetEntities()) {
                LogDebug(LogTagDef.SkillLogTag, "Clean skill view: {0}", 
                    skillEntity.hasSkillSequence ? skillEntity.skillSequence.Path : string.Empty);
                RecycleAndDestroy(skillEntity);
            }
        }

        public void TearDown() {
            foreach (var skillEntity in _group.GetEntities()) {
                
            }
        }

        private void RecycleAndDestroy(ViewSkillEntity skillEntity) {
            // TODO 快照处理
            skillEntity.RecycleSequence();
            skillEntity.Destroy();
        }
    }
}
