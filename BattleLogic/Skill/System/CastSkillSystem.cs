//------------------------------------------------------------
//        File:  CastSkillSystem.cs
//       Brief:  CastSkillSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-16
//============================================================

using System.Collections.Generic;
using Battle.Logic.Base.System;
using Battle.Logic.Constant;
using Entitas;

namespace Battle.Logic.Skill.System
{
    internal class CastSkillSystem : LogicReactiveSystem<LogicSkillEntity>
    {
        private static readonly IMatcher<LogicSkillEntity> SkillMatcher = LogicSkillMatcher.SkillCastContext;

        public CastSkillSystem(LogicContexts contexts) : base(contexts, contexts.logicSkill) {
        }

        protected override ICollector<LogicSkillEntity> GetTrigger(IContext<LogicSkillEntity> context) {
            return context.CreateCollector(SkillMatcher);
        }

        protected override bool Filter(LogicSkillEntity entity) {
            return entity.hasSkillCastContext && entity.hasId;
        }

        protected override void Execute(List<LogicSkillEntity> entities) {
            foreach (var skillEntity in entities) {
                var skillContext = skillEntity.skillCastContext;
                LogDebug(LogTagDef.SkillLogTag, "Skill context added, caster id: {0}, skill guid: {1}, target id: {2}",
                    skillContext.CasterId, skillContext.Ability.Guid, skillContext.TargetId);

                ReadAndProcessSkillSequence(skillEntity);
            }
        }

        private void ReadAndProcessSkillSequence(LogicSkillEntity skillEntity) {
            var skillContext = skillEntity.skillCastContext;
            var skillConfData = skillContext.Ability;

            // 持续性技能
            if (skillConfData.ActiveSkillData.BaseData.IsContinuous) {
                // 配置的持续时间 <= 0
                if (skillConfData.ActiveSkillData.BaseData.Duration <= 0) {
                    LogError(LogTagDef.SkillLogTag,
                        "Skill mark as continuous, but duration is less or equal than 0, guid: {0}",
                        skillConfData.Guid);
                    return;
                }
                
                // 没有配置持续技能序列
                if (string.IsNullOrEmpty(skillConfData.ActiveSkillData.ContinuousTimelineData?.SequencePath)) {
                    LogError(LogTagDef.SkillLogTag,
                        "Skill mark as continuous, but no continuous sequence specified, guid: {0}",
                        skillConfData.Guid);
                    return;
                }
            }
            
            
        }
    }
}