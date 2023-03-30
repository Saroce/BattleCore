//------------------------------------------------------------
//        File:  CastState.cs
//       Brief:  CastState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
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

            if (!(context is CastStateContext stateContext)) {
                return false;
            }

            // TODO 
            return false;
        }

        public override void OnEnter(IEntity entity) {
            
        }

        public override void OnExit(IEntity entity) {
            
        }

        public override void OnUpdate(IEntity entity) {
            
        }
    }
}