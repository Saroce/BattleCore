//------------------------------------------------------------
//        File:  ThingMessageBase.cs
//       Brief:  ThingMessageBase
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Constant;

namespace Battle.Common.Context.Message.Thing
{
    public interface IThingMessageBase : IBattleMessage
    {
        ulong Id { get; set; }
        
        ThingType ThingType { get; set; }
    }
    
    public class ThingMessageBase : BattleMessage, IThingMessageBase
    {
        public ulong Id { get; set; }
        
        public ThingType ThingType { get; set; }
    }
}
