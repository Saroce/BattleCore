//------------------------------------------------------------
//        File:  ThingEnterIdleMessage.cs
//       Brief:  ThingEnterIdleMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

namespace Battle.Common.Context.Message.Thing
{
    public class ThingEnterIdleMessage : ThingMessageBase<ThingEnterCastMessage>
    {
        public string MotionName;
    }
}