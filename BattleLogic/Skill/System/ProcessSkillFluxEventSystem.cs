//------------------------------------------------------------
//        File:  ProcessSkillFluxEventSystem.cs
//       Brief:  ProcessSkillFluxEventSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using System;
using Battle.Common.Constant;
using Battle.Logic.Base.System;
using Battle.Logic.Skill.Component.Flux;
using Battle.Logic.Skill.Utils;
using Entitas;


namespace Battle.Logic.Skill.System
{
    internal class ProcessSkillFluxEventSystem : LogicExecuteSystem
    {
        private static readonly IMatcher<LogicSkillEntity> SkillMatcher = LogicSkillMatcher.AllOf(
            LogicSkillMatcher.SkillFluxEvents,
            LogicSkillMatcher.SkillCastTime,
            LogicSkillMatcher.SkillCasterId
        );

        private readonly IGroup<LogicSkillEntity> _group;

        public ProcessSkillFluxEventSystem(LogicContexts contexts) : base(contexts) {
            _group = contexts.logicSkill.GetGroup(SkillMatcher);
        }

        public override void Execute() {
            var curTime = Contexts.GetClock().GetTime();
            foreach (var skillEntity in _group.GetEntities()) {
                var startTime = skillEntity.skillCastTime.Value;
                var escape = curTime - startTime;
                var toRemove = ListPool<SkillFluxEventContext>().Get();
                foreach (var fluxEventContext in skillEntity.skillFluxEvents.Value) {
                    // 到达技能序列事件触发时间
                    if (escape >= fluxEventContext.Time) {
                        ProcessSkillEvent(skillEntity, fluxEventContext);
                        toRemove.Add(fluxEventContext);
                    }
                }

                foreach (var fluxEventContext in toRemove) {
                    skillEntity.skillFluxEvents.Value.Remove(fluxEventContext);
                }
                ListPool<SkillFluxEventContext>().Return(toRemove);

                // 当前技能序列事件已全部处理完
                if (skillEntity.skillFluxEvents.Value.Count <= 0) {
                    ListPool<SkillFluxEventContext>().Return(skillEntity.skillFluxEvents.Value);
                    skillEntity.RemoveSkillFluxEvents();
                }
            }
        }

        /// <summary>
        /// 处理技能序列事件
        /// </summary>
        /// <param name="skillEntity"></param>
        /// <param name="fluxEventContext"></param>
        private void ProcessSkillEvent(LogicSkillEntity skillEntity, SkillFluxEventContext fluxEventContext) {
            var casterId = skillEntity.skillCasterId.Value;
            var targetId = 0ul;
            if (skillEntity.hasSkillTargetId) {
                targetId = skillEntity.skillTargetId.Value;
            }

            switch (fluxEventContext.Type) {
                case SkillFluxEventType.Judge:
                    SkillJudgeUtil.ProcessJudge(Contexts, casterId, targetId, fluxEventContext as JudgeFluxEventContext);
                    break;
                case SkillFluxEventType.Shoot:
                    SkillShootUtil.ProcessShoot(Contexts, casterId, targetId, fluxEventContext as ShootFluxEventContext);
                    break;
                default:
                    throw new IndexOutOfRangeException($"Unhandled flux event type:{fluxEventContext.Type}");
            }
        }
    }
}