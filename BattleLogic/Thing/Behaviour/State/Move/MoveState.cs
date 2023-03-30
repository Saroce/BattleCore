//------------------------------------------------------------
//        File:  MoveState.cs
//       Brief:  MoveState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
using Battle.Logic.Thing.Extension;
using Entitas;

namespace Battle.Logic.Thing.Behaviour.State.Move
{
    internal class MoveState : Base.FSM.State
    {
        public MoveState(IStateMachine fsm) : base(fsm) {
        }

        public override bool CanTransit(IEntity entity, IStateContext context = null) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return false;
            }

            return thingEntity.IsMovable();
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