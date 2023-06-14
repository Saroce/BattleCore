//------------------------------------------------------------
//        File:  ThingExtension.cs
//       Brief:  ThingExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Constant;
using vFrame.Lockstep.Core;

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
        
        /// <summary>
        /// 计算两个物件间的距离
        /// </summary>
        /// <param name="thingA"></param>
        /// <param name="thingB"></param>
        /// <returns></returns>
        public static FixedPoint GetDistance(this LogicThingEntity thingA, LogicThingEntity thingB) {
            if (!thingA.hasPosition || !thingB.hasPosition) {
                return FixedPoint.MaxValue;
            }

            var radiusA = thingA.hasRadius ? thingA.radius.Value : 0;
            var radiusB = thingB.hasRadius ? thingB.radius.Value : 0;

            var positionA = thingA.position.Value;
            var positionB = thingB.position.Value;

            return (positionA - positionB).magnitude - radiusA - radiusB;
        }
    }
}