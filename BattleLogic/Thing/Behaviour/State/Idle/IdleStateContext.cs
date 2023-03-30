//------------------------------------------------------------
//        File:  IdleStateContext.cs
//       Brief:  IdleStateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Logic.Base.FSM;
using Core.Lite.RefPool;

namespace Battle.Logic.Thing.Behaviour.State.Idle
{
    public class IdleStateContext : IStateContext, IRefReset
    {
        public bool Force { get; set; }
        
        public void Reset() {
            Force = false;
        }
    }
}