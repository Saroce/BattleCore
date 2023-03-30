//------------------------------------------------------------
//        File:  CreatureFactory.cs
//       Brief:  CreatureFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Create;
using Battle.Logic.Base.FSM;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Behaviour.State.Cast;
using Battle.Logic.Thing.Behaviour.State.Dead;
using Battle.Logic.Thing.Behaviour.State.Idle;
using Battle.Logic.Thing.Behaviour.State.Move;
using Battle.Logic.Thing.Behaviour.State.OutOfControl;

namespace Battle.Logic.Thing.Factory
{
    internal static class CreatureFactory
    {
        internal static void CreateCreature(this LogicContexts contexts, LogicThingEntity thingEntity,
            CreatureCreateContext context) {

            // 添加状态机
            var fsm = new StateMachine(thingEntity);
            fsm.Create(contexts);
            
            fsm.AddState((int) BehaviourType.Idle, new IdleState(fsm));
            fsm.AddState((int) BehaviourType.Moving, new MoveState(fsm));
            fsm.AddState((int) BehaviourType.Casting, new CastState(fsm));
            fsm.AddState((int) BehaviourType.Dead, new DeadState(fsm));
            fsm.AddState((int) BehaviourType.OutOfControl, new OutOfControlState(fsm));
            
            thingEntity.AddStateMachine(fsm);
            thingEntity.AddIdlableRef(1);
            thingEntity.AddMovableRef((context.ThingFlag & ThingFlag.Dynamic) > 0 ? 1 : 0);
            thingEntity.AddCastableRef(1);
            
            thingEntity.isCreature = true;
        }
    }
}