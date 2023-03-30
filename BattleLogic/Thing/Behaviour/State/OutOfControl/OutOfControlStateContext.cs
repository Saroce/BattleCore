//------------------------------------------------------------
//        File:  OutOfControlStateContext.cs
//       Brief:  OutOfControlStateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Common.Constant;
using Battle.Logic.Base.FSM;
using Core.Lite.RefPool;

namespace Battle.Logic.Thing.Behaviour.State.OutOfControl
{
    internal class OutOfControlStateContext : IStateContext, IRefReset
    {
        public ThingOutOfControlType OutOfControlType;
        
        public void Reset() {
            
        }
    }
}