//------------------------------------------------------------
//        File:  ThingHpUpdateMessage.cs
//       Brief:  ThingHpUpdateMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using vFrame.Lockstep.Core;

namespace Battle.Common.Context.Message.Thing
{
    public class ThingHpUpdateMessage : ThingMessageBase<ThingHpUpdateMessage>
    {
        public FixedPoint OldValue;
        public FixedPoint NewValue;
        public FixedPoint Maximum;
    }
}