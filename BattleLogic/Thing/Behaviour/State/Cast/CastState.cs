//------------------------------------------------------------
//        File:  CastState.cs
//       Brief:  CastState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
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
            
            // TODO 
            return thingEntity.IsCastable();
        }

        public override void OnEnter(IEntity entity) {
            
        }

        public override void OnExit(IEntity entity) {
            
        }

        public override void OnUpdate(IEntity entity) {
            
        }
    }
}