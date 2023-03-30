//------------------------------------------------------------
//        File:  DeadState.cs
//       Brief:  DeadState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
using Entitas;

namespace Battle.Logic.Thing.Behaviour.State.Dead
{
    internal class DeadState : Base.FSM.State
    {
        public DeadState(IStateMachine fsm) : base(fsm) {
        }

        public override bool CanTransit(IEntity entity, IStateContext context = null) {
            if (!(entity is LogicThingEntity thingEntity)) {
                return false;
            }

            return !thingEntity.isDead;
        }

        public override void OnEnter(IEntity entity) {
            
        }

        public override void OnExit(IEntity entity) {
            
        }

        public override void OnUpdate(IEntity entity) {
            
        }
    }
}