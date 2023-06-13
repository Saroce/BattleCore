//------------------------------------------------------------
//        File:  IdleState.cs
//       Brief:  IdleState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Common.Context.Message.Thing;
using Battle.Logic.Base.FSM;
using Battle.Logic.Thing.Extension;
using Entitas;

namespace Battle.Logic.Thing.Behaviour.State.Idle
{
    internal class IdleState : Base.FSM.State
    {
        public IdleState(IStateMachine fsm) : base(fsm) {
        }

        /// <summary>
        /// 是否可以切换到Idle状态
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool CanTransit(IEntity entity, IStateContext context = null) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return false;
            }

            if (context is IdleStateContext stateContext) {
                if (stateContext.Force) {
                    return true;
                }
            }

            return thingEntity.IsIdlable();
        }

        public override void OnEnter(IEntity entity) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return;
            }
            
            SendEnterIdleMessage(thingEntity);
            thingEntity.isIdleState = true;
        }

        public override void OnExit(IEntity entity) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return;
            }

            thingEntity.isIdleState = false;
        }

        public override void OnUpdate(IEntity entity) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return;
            }
            
            SendEnterIdleMessage(thingEntity);
        }

        private void SendEnterIdleMessage(LogicThingEntity thingEntity) {
            var motionName = string.Empty;
            if (thingEntity.hasIdleMotionName) {
                motionName = thingEntity.idleMotionName.Value;
            }

            var message = RefPool<ThingEnterIdleMessage>().Get();
            message.Id = thingEntity.id.Value;
            message.ThingType = thingEntity.GetThingType();
            message.MotionName = motionName;
            SendMessage(message);
        }
    }
}