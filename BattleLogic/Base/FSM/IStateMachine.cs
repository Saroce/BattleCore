//------------------------------------------------------------
//        File:  IStateMachine.cs
//       Brief:  IStateMachine
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Entitas;

namespace Battle.Logic.Base.FSM
{
    public interface IStateMachine
    {
        void AddState(int stateId, IState state);

        void RemoveState(int stateId);

        bool ChangeState(int stateId, IStateContext context = null);

        IState GetCurState();

        int GetCurStateId();

        IContexts GetContexts();
    }
}