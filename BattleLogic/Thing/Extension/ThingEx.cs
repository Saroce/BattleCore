//------------------------------------------------------------
//        File:  ThingExtension.cs
//       Brief:  ThingExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Core.Lite.RefPool.Builtin;
using Core.Lockstep.Math;

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

        public static FixedPoint GetCastSpeedScale(this LogicThingEntity thingEntity, LogicContexts contexts,
            SkillConfData ability) {
            // TODO 暂时默认返回1
            return ThingCastSpeed.Default;
        }
        
        public static string GetThingSummary(this LogicThingEntity thingEntity) {
            var builder = StringBuilderPool.Shared.Get();
            builder.Append("[ThingType: ");
            builder.Append(thingEntity.GetThingType());

            if (thingEntity.hasId) {
                builder.Append(", Id: ");
                builder.Append(thingEntity.id.Value);
            }

            builder.Append("]");
            return builder.ToString();
        }
    }
}