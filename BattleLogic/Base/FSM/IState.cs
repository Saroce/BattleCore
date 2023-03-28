//------------------------------------------------------------
//        File:  IState.cs
//       Brief:  IState
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Entitas;

namespace Battle.Logic.Base.FSM
{
    public interface IState
    {
        bool CanTransit(IEntity entity, IStateContext context = null);

        void OnEnter(IEntity entity);

        void OnExit(IEntity entity);

        void OnUpdate(IEntity entity);
        
        IStateContext StateContext { get; set; }
    }
}