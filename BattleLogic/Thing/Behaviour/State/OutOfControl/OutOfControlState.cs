//------------------------------------------------------------
//        File:  OutOfControlState.cs
//       Brief:  OutOfControlState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
using Entitas;

namespace Battle.Logic.Thing.Behaviour.State.OutOfControl
{
    internal class OutOfControlState : Base.FSM.State
    {
        public OutOfControlState(IStateMachine fsm) : base(fsm) {
        }

        public override bool CanTransit(IEntity entity, IStateContext context = null) {
            return true;
        }

        public override void OnEnter(IEntity entity) {

        }

        public override void OnExit(IEntity entity) {

        }

        public override void OnUpdate(IEntity entity) {

        }
    }
}