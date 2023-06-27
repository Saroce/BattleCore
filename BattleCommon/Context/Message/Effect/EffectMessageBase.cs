//------------------------------------------------------------
//        File:  EffectMessageBase.cs
//       Brief:  EffectMessageBase
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Combat;

namespace Battle.Common.Context.Message.Effect
{
    public class EffectMessageBase<T> : BattleMessage<T> where T : class
    {
        public ulong TargetId { get; set; }
        public EffectSource Source { get; set; }
        public EffectUserData UserData { get; set; }
    }
}
