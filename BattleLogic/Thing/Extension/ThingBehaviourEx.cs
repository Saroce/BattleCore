//------------------------------------------------------------
//        File:  ThingBehaviourExtension.cs
//       Brief:  ThingBehaviourExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Behaviour.State.Cast;
using Battle.Logic.Thing.Behaviour.State.Dead;
using Battle.Logic.Thing.Behaviour.State.Idle;
using Battle.Logic.Thing.Behaviour.State.Move;
using Battle.Logic.Thing.Behaviour.State.OutOfControl;

namespace Battle.Logic.Thing.Extension
{
    internal static class ThingBehaviourEx
    {
        private static bool ChangeState(this LogicThingEntity thingEntity, int stateId, IStateContext stateContext) {
            if (!thingEntity.hasStateMachine) {
                return false;
            }

            var fsm = thingEntity.stateMachine.FSM;
            return fsm.ChangeState(stateId, stateContext);
        }
        
        public static bool IsIdlable(this LogicThingEntity thingEntity) {
            return thingEntity.hasIdlableRef && thingEntity.idlableRef.Value > 0;
        }
        
        public static bool IsMovable(this LogicThingEntity thingEntity) {
            return thingEntity.hasMovableRef && thingEntity.movableRef.Value > 0;
        }
        
        public static bool IsCastable(this LogicThingEntity thingEntity) {
            return thingEntity.hasCastableRef && thingEntity.castableRef.Value > 0;
        }

        public static bool Idle(this LogicThingEntity thingEntity, LogicContexts contexts, bool force) {
            var stateContext = contexts.RefPool<IdleStateContext>().Get();
            stateContext.Force = force;
            return thingEntity.ChangeState((int)BehaviourType.Idle, stateContext);
        }

        public static bool Idle(this LogicThingEntity thingEntity, LogicContexts contexts, IdleStateContext context = null) {
            return thingEntity.ChangeState((int)BehaviourType.Idle, context ?? contexts.RefPool<IdleStateContext>().Get());
        }
        
        public static bool Move(this LogicThingEntity thingEntity, LogicContexts contexts, MoveStateContext context = null) {
            return thingEntity.ChangeState((int)BehaviourType.Move, context ?? contexts.RefPool<MoveStateContext>().Get());
        }
        
        public static bool Cast(this LogicThingEntity thingEntity, LogicContexts contexts, CastStateContext context = null) {
            return thingEntity.ChangeState((int)BehaviourType.Cast, context ?? contexts.RefPool<CastStateContext>().Get());
        }
        
        public static bool OutOfControl(this LogicThingEntity thingEntity, LogicContexts contexts, OutOfControlStateContext context = null) {
            return thingEntity.ChangeState((int)BehaviourType.OutOfControl, context ?? contexts.RefPool<OutOfControlStateContext>().Get());
        }
        
        public static bool Dead(this LogicThingEntity thingEntity, LogicContexts contexts, DeadStateContext context = null) {
            return thingEntity.ChangeState((int)BehaviourType.Dead, context ?? contexts.RefPool<DeadStateContext>().Get());
        }
    }
}