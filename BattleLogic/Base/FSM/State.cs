//------------------------------------------------------------
//        File:  State.cs
//       Brief:  State
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Entitas;

namespace Battle.Logic.Base.FSM
{
    internal abstract class State : LogicContextsBridge, IState
    {
        protected State(IStateMachine fsm) {
            Create(fsm.GetContexts() as LogicContexts);
        }

        public abstract bool CanTransit(IEntity entity, IStateContext context = null);

        public abstract void OnEnter(IEntity entity);

        public abstract void OnExit(IEntity entity);

        public abstract void OnUpdate(IEntity entity);

        public IStateContext StateContext { get; set; }
    }
}
