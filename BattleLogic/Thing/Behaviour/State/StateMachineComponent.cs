//------------------------------------------------------------
//        File:  StateMachineComponent.cs
//       Brief:  StateMachineComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Battle.Logic.Base.Component;
using Battle.Logic.Base.FSM;

namespace Battle.Logic.Thing.Behaviour.State
{
    [LogicThing]
    public class StateMachineComponent : LogicComponent
    {
        public IStateMachine FSM;
    }
}
