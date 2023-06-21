//------------------------------------------------------------
//        File:  ThingCreateMessage.cs
//       Brief:  ThingCreateMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Context.Create;

namespace Battle.Common.Context.Message.Thing
{
    public class ThingCreateMessage : ThingMessageBase<ThingCreateMessage>
    {
        public ThingCrateContext CreateContext { get; set; }
    }
}
