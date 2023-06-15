//------------------------------------------------------------
//        File:  CastState.cs
//       Brief:  CastState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Common.Context.Message.Thing;
using Battle.Logic.Base.FSM;
using Battle.Logic.Constant;
using Battle.Logic.Skill;
using Battle.Logic.Thing.Extension;
using Entitas;

namespace Battle.Logic.Thing.Behaviour.State.Cast
{
    internal class CastState : Base.FSM.State
    {
        public CastState(IStateMachine fsm) : base(fsm) {
            
        }

        public override bool CanTransit(IEntity entity, IStateContext context = null) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return false;
            }

            if (context == null) {
                return false;
            }

            var castContext = (CastStateContext) context;
            // 正在施法中
            if (StateContext != null) {
                var curContext = ((CastStateContext) StateContext).Ability;
                // 相同技能id不能重复施法
                if (curContext.Guid == castContext.Ability.Guid) {
                    return false;
                }

                // 当前施法不能被替换
                if (!curContext.ActiveSkillData.BaseData.CanReplace) {
                    return false;
                }
            }
            
            return thingEntity.IsCastable();
        }

        public override void OnEnter(IEntity entity) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return;
            }

            var curContext = (CastStateContext)StateContext;
            
            LogDebug(LogTagDef.StateLogTag, "Enter cast state, thing: {0}, skill guid: {1}, target: {2}, speed: {3}",
                thingEntity.GetThingSummary(),
                curContext.Ability.Guid,
                curContext.TargetId,
                thingEntity.GetCastSpeedScale(Contexts, curContext.Ability));

            // 创建逻辑层施法实体
            CastSkill(thingEntity, curContext);
            // TODO 处理技能释放而消耗的数据，例如蓝，怒气数值等
            RetainStateRef(thingEntity);
            SendEnterCastMessage(thingEntity, curContext);

            thingEntity.isCastState = true;
        }

        private void CastSkill(LogicThingEntity thingEntity, CastStateContext stateContext) {
            Contexts.logicSkill.CastSkill(Contexts, thingEntity, stateContext.TargetId, stateContext.Ability);
        }

        private void RetainStateRef(LogicThingEntity thingEntity) {
            thingEntity.ReplaceIdlableRef(thingEntity.idlableRef.Value - 1);
            thingEntity.ReplaceMovableRef(thingEntity.movableRef.Value - 1);
        }

        private void SendEnterCastMessage(LogicThingEntity thingEntity, CastStateContext stateContext) {
            var message = RefPool<ThingEnterCastMessage>().Get();
            message.Id = thingEntity.id.Value;
            message.ThingType = thingEntity.GetThingType();
            message.TargetId = stateContext.TargetId;
            message.Ability = stateContext.Ability;
            message.CastSpeed = thingEntity.GetCastSpeedScale(Contexts, stateContext.Ability);
            
            SendMessage(message);
        }

        public override void OnUpdate(IEntity entity) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return;
            }

            var curContext = (CastStateContext)StateContext;
            
            LogDebug(LogTagDef.StateLogTag, "Update cast state, thing: {0}, skill guid: {1}, target: {2}, speed: {3}",
                thingEntity.GetThingSummary(),
                curContext.Ability.Guid,
                curContext.TargetId,
                thingEntity.GetCastSpeedScale(Contexts, curContext.Ability));
            
            CastSkill(thingEntity, curContext);
            // TODO 处理技能释放而消耗的数据，例如蓝，怒气数值等
            SendEnterCastMessage(thingEntity, curContext);
        }
        
        public override void OnExit(IEntity entity) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return;
            }

            var curContext = (CastStateContext)StateContext;
            LogDebug(LogTagDef.StateLogTag, "Exit cast state, thing: {0}, skill guid: {1}, target: {2}, speed: {3}",
                thingEntity.GetThingSummary(),
                curContext.Ability.Guid,
                curContext.TargetId,
                thingEntity.GetCastSpeedScale(Contexts, curContext.Ability));

            ReleaseStateRef(thingEntity);
            SendExitStateMessage(thingEntity, curContext);
            
            thingEntity.isCastState = false;
        }

        private void ReleaseStateRef(LogicThingEntity thingEntity) {
            thingEntity.ReplaceIdlableRef(thingEntity.idlableRef.Value + 1);
            thingEntity.ReplaceMovableRef(thingEntity.movableRef.Value + 1);
        }

        private void SendExitStateMessage(LogicThingEntity thingEntity, CastStateContext stateContext) {
            var message = RefPool<ThingExitCastMessage>().Get();
            message.Id = thingEntity.id.Value;
            message.ThingType = thingEntity.GetThingType();
            message.Ability = stateContext.Ability;
            
            SendMessage(message);
        }
    }
}