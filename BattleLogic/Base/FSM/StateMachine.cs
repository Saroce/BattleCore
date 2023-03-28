//------------------------------------------------------------
//        File:  StateMachine.cs
//       Brief:  StateMachine
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using System.Collections.Generic;
using Battle.Common.Exception;
using Entitas;

namespace Battle.Logic.Base.FSM
{
    internal class StateMachine : LogicContextsBridge, IStateMachine
    {
        protected readonly IEntity Entity;
        protected readonly Dictionary<int, IState> States;
        protected IState CurState;
        
        public StateMachine(IEntity entity) {
            Entity = entity;
            States = new Dictionary<int, IState>();
        }
        
        public void AddState(int stateId, IState state) {
            if (!States.ContainsKey(stateId)) {
                throw new StateAlreadyExistException(stateId);
            }

            States.Add(stateId, state);
        }

        public void RemoveState(int stateId) {
            if (!States.ContainsKey(stateId)) {
                throw new StateNotExistException(stateId);
            }

            if (States[stateId] == CurState) {
                ExistCurState();
            }

            States.Remove(stateId);
        }

        private void ExistCurState() {
            if (CurState == null) {
                return;
            }
            CurState.OnExit(Entity);
            CurState = null;
        }
        
        public bool ChangeState(int stateId, IStateContext context = null) {
            if (!States.ContainsKey(stateId)) {
                throw new StateNotExistException(stateId);
            }

            var state = States[stateId];
            if (state == null || !state.CanTransit(Entity, context)) {
                return false;
            }
            
            if (state == CurState) {
                state.OnUpdate(Entity);
                return true;
            }
            
            ExistCurState();
            CurState = state;
            CurState.OnEnter(Entity);
            return true;
        }

        public IState GetCurState() {
            return CurState;
        }

        public int GetCurStateId() {
            foreach (var kv in States) {
                if (kv.Value == CurState) {
                    return kv.Key;
                }
            }

            return -1;
        }

        public IContexts GetContexts() {
            return Contexts;
        }
    }
}