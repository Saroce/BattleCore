//------------------------------------------------------------
//        File:  StateMachine.cs
//       Brief:  StateMachine
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using System.Collections.Generic;
using Battle.Common.Exceptions;
using Entitas;
using NotImplementedException = System.NotImplementedException;

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

            if (CurState.StateContext != null) {
                Contexts.RefPoolManager().TryReturn(CurState.StateContext);
            }

            CurState.StateContext = null;
            CurState = null;
        }
        
        public bool ChangeState(int stateId, IStateContext context = null) {
            if (!States.ContainsKey(stateId)) {
                throw new StateNotExistException(stateId);
            }

            var state = States[stateId];
            if (!state.CanTransit(Entity, context)) {
                if (context != null) {
                    Contexts.RefPoolManager().TryReturn(context);
                }
                return false;
            }
            
            // 更新当前状态
            if (state == CurState) {
                UpdateCurState(context);
                return true;
            }
            
            // 退出前状态
            ExistCurState();
            
            // 进入当前状态
            CurState = state;
            CurState.StateContext = context;
            CurState.OnEnter(Entity);
            
            return true;
        }

        public void ExitState(int stateId) {
            if (!States.ContainsKey(stateId))
                throw new StateNotExistException(stateId);

            var state = States[stateId];
            if (CurState != state) {
                return;
            }
            
            ExistCurState();
        }

        protected virtual void UpdateCurState(IStateContext context) {
            var state = GetCurState();
            if (state == null) {
                return;
            }

            if (state.StateContext != null) {
                Contexts.RefPoolManager().TryReturn(state.StateContext);
            }

            state.StateContext = context;
            state.OnUpdate(Entity);
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