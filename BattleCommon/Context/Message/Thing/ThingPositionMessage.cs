//------------------------------------------------------------
//        File:  ThingPositionMessage.cs
//       Brief:  ThingPositionMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using vFrame.Lockstep.Core;

namespace Battle.Common.Context.Message.Thing
{
    public class ThingPositionMessage : ThingMessageBase<ThingEnterCastMessage>
    {
        public TSVector Position;
    }
}