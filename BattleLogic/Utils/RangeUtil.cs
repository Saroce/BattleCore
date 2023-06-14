//------------------------------------------------------------
//        File:  RangeUtil.cs
//       Brief:  RangeUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-14
//============================================================

using System;
using SkillModule.Runtime.Skill;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Utils
{
    internal static class RangeUtil
    {
        /// <summary>
        /// 判断施法范围是否覆盖目标点
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="origin"></param>
        /// <param name="rotation"></param>
        /// <param name="target"></param>
        /// <param name="radius"></param>
        /// <param name="rangeData"></param>
        /// <returns></returns>
        public static bool IsRangeOverlap(LogicContexts contexts, TSVector origin, TSQuaternion rotation,
            TSVector target, FixedPoint radius, SkillRangeData rangeData) {
            switch (rangeData.RangeType) {
                case SkillCastRangeType.Rectangle: {
                    return IsRectangleOverlap(origin, rotation, target, radius, (FixedPoint)rangeData.RangeWidth / 100f,
                        (FixedPoint)rangeData.RangeHeight / 100f, (FixedPoint)rangeData.RangeYOffset / 100f);
                }
                case SkillCastRangeType.Sector: {
                    return IsSectorOverlap(origin, rotation, target, radius, (FixedPoint)rangeData.RangeRadius / 100f,
                        (FixedPoint)rangeData.RangeAngle / 100f, (FixedPoint)rangeData.RangeYOffset / 100f);
                }
                default:
                    throw new ArgumentOutOfRangeException($"Unhandled range type:{rangeData.RangeType}");
            }
        }

        /// <summary>
        /// 判断矩形范围是否覆盖目标点
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="rotation"></param>
        /// <param name="target"></param>
        /// <param name="radius"></param>
        /// <param name="rangeWidth"></param>
        /// <param name="rangeHeight"></param>
        /// <param name="rangeYOffset"></param>
        /// <returns></returns>
        public static bool IsRectangleOverlap(TSVector origin, TSQuaternion rotation, TSVector target,
            FixedPoint radius, FixedPoint rangeWidth, FixedPoint rangeHeight, FixedPoint rangeYOffset) {
            // 因为这里设计的判断范围高度是大于宽度的，先判断距离
            var distance = TSVector.Distance(origin, target);
            var maxDistance = rangeHeight + rangeYOffset + radius;
            if (distance > maxDistance) {
                return false;
            }

            // 先将target圆中心点位置转换成相对于origin的轴对称坐标位置
            var delta = target - origin;
            var inverseQuaternion = TSQuaternion.Inverse(rotation);
            var rotatedDelta = inverseQuaternion * delta;
            var circleCenter = TransformUtil.ToVector2(rotatedDelta);

            // 构建技能范围的矩形
            var rect = new TSRect(-0.5f * rangeWidth, rangeYOffset, rangeWidth, rangeHeight);
            var rectCenter = rect.center;
            // 目标圆心坐标 - 矩形中心坐标
            var dtCenter = circleCenter - rectCenter;
            // 映射到第一象限
            var v = new TSVector2(TSMath.Abs(dtCenter.x), TSMath.Abs(dtCenter.y));
            // 求出矩形的半长
            var h = rect.max - rect.center;
            // 求出目标圆心到矩形最短距离的矢量u，并将负数的分量设置为0
            var u = TSVector2.Max(v - h, TSVector2.zero);
            // 将u的距离跟圆心的半径比较可得是否相交
            return TSVector2.Dot(u, u) <= radius * radius;
        }

        /// <summary>
        /// 判断扇形范围是否覆盖目标点
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="rotation"></param>
        /// <param name="target"></param>
        /// <param name="radius"></param>
        /// <param name="rangeRadius"></param>
        /// <param name="rangeAngle"></param>
        /// <param name="rangeYOffset"></param>
        /// <returns></returns>
        public static bool IsSectorOverlap(TSVector origin, TSQuaternion rotation, TSVector target,
            FixedPoint radius, FixedPoint rangeRadius, FixedPoint rangeAngle, FixedPoint rangeYOffset) {
            // TODO 扇形与圆的相交判断
            return false;
        }
    }
}