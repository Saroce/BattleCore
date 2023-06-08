//------------------------------------------------------------
//        File:  ThingExtension.cs
//       Brief:  ThingExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Constant;

namespace Battle.Logic.Thing.Extension
{
    internal static class ThingEx
    {
        public static ThingType GetThingType(this LogicThingEntity thingEntity) {
            if (thingEntity.isGamer) {
                return ThingType.Gamer;
            }
            
            // TODO 

            return ThingType.Unknown;
        }
    }
}