//------------------------------------------------------------
//        File:  ExitCastStateOnFinishedSystem.cs
//       Brief:  ExitCastStateOnFinishedSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.System;
using Battle.Logic.Common.Event.Skill;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Extension;

namespace Battle.Logic.Thing.Behaviour.State.Cast.System
{
    internal class ExitCastStateOnFinishedSystem : LogicEventSystem<SkillCastFinishedEvent>
    {
        public ExitCastStateOnFinishedSystem(LogicContexts contexts) : base(contexts) {
        }

        protected override void OnEvent(SkillCastFinishedEvent context) {
            var thingEntity = Contexts.logicThing.GetEntityWithId(context.CasterId);
            if (null == thingEntity) {
                LogDebug(LogTagDef.SkillLogTag,
                    "Skill finished, but caster entity has destroyed, id: {0}", context.CasterId);
                return;
            }

            if (thingEntity.isDead) {
                LogDebug(LogTagDef.SkillLogTag, "Skill finished, but caster entity has dead, id: {0}",
                    context.CasterId);
                return;
            }

            var fsm = thingEntity.stateMachine.FSM;
            if (fsm.GetCurStateId() != (int) BehaviourType.Cast) {
                return;
            }

            var state = fsm.GetCurState();
            var castContext = (CastStateContext) state.StateContext;
            // 完成技能与当前施法状态不符合
            if (castContext.Ability.Guid != context.SkillConfData.Guid) {
                return;
            }

            // 施法完毕，切换置Idle状态
            thingEntity.ExitState((int) BehaviourType.Cast);
            thingEntity.Idle(Contexts);
        }
    }
}