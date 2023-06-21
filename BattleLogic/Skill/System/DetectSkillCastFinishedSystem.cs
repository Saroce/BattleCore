//------------------------------------------------------------
//        File:  DetectSkillCastFinishedSystem.cs
//       Brief:  DetectSkillCastFinishedSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.System;
using Battle.Logic.Common.Event.Skill;
using Battle.Logic.Constant;
using Entitas;

namespace Battle.Logic.Skill.System
{
    internal class DetectSkillCastFinishedSystem : LogicExecuteSystem
    {
        private static readonly IMatcher<LogicSkillEntity> SkillMatcher = LogicSkillMatcher.AllOf(
            LogicSkillMatcher.SkillCastContext,
            LogicSkillMatcher.SkillCastDuration
        ).NoneOf(LogicSkillMatcher.Destroyed);

        private readonly IGroup<LogicSkillEntity> _group;

        public DetectSkillCastFinishedSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicSkill.GetGroup(SkillMatcher);
        }

        public override void Execute() {
            var curTime = Contexts.GetClock().GetTime();
            foreach (var skillEntity in _group.GetEntities()) {
                var startTime = skillEntity.skillCastTime.Value;
                var duration = skillEntity.skillCastDuration.Value;
                if (curTime - startTime < duration) {
                    continue;
                }
                
                LogDebug(LogTagDef.SkillLogTag, "Skill finished, caster id: {0}, skill guid: {1}",
                    skillEntity.skillCastContext.CasterId, skillEntity.skillCastContext.Ability.Guid);

                // 标记为完成，下一帧由DestroySkillOnFinishSystem进行清除
                skillEntity.isSkillFinished = true;

                // 发送事件，通知施法完毕，需要从Cast状态切换至Idle状态
                var @event = Contexts.RefPool<SkillCastFinishedEvent>().Get();
                @event.EntityId = skillEntity.id.Value;
                @event.CasterId = skillEntity.skillCastContext.CasterId;
                @event.TargetId = skillEntity.skillCastContext.TargetId;
                @event.SkillConfData = skillEntity.skillCastContext.Ability;
                SendEvent(@event);
            }
        }
    }
}