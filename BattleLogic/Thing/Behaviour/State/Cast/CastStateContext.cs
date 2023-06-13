//------------------------------------------------------------
//        File:  CastStateContext.cs
//       Brief:  CastStateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Base.FSM;
using Core.Lite.RefPool;

namespace Battle.Logic.Thing.Behaviour.State.Cast
{
    public class CastStateContext : IStateContext, IRefReset
    {
        public SkillConfData Ability;
        public ulong TargetId;
        
        public void Reset() {
            Ability = null;
            TargetId = 0;
        }
    }
}