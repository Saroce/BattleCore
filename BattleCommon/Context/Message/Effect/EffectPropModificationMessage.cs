//------------------------------------------------------------
//        File:  EffectPropModificationMessage.cs
//       Brief:  EffectPropModificationMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using vFrame.Lockstep.Core;

namespace Battle.Common.Context.Message.Effect
{
    public class EffectPropModificationMessage : EffectMessageBase<EffectPropModificationMessage>
    {
        public int PropertyType { get; set; }
        public FixedPoint DeltaValue { get; set; }
        public string FormulaId { get; set; }
    }
}
