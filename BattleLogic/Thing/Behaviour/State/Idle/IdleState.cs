//------------------------------------------------------------
//        File:  IdleState.cs
//       Brief:  IdleState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

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
            // TODO 
        }

        public override void OnExit(IEntity entity) {
            // TODO 
        }

        public override void OnUpdate(IEntity entity) {
            // TODO 
        }
    }
}