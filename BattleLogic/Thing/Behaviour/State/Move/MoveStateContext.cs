//------------------------------------------------------------
//        File:  MoveStateContext.cs
//       Brief:  MoveStateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
using Core.Lite.RefPool;
using Core.Lockstep.Math;

namespace Battle.Logic.Thing.Behaviour.State.Move
{
    public class MoveStateContext : IStateContext, IRefReset
    {
        public TSVector Velocity;
        
        public void Reset() {
            Velocity = TSVector.zero;
        }
    }
}