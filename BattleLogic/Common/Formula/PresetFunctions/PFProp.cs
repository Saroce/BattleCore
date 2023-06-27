//------------------------------------------------------------
//        File:  PFProp.cs
//       Brief:  PFProp
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-26
//============================================================

using System;
using Battle.Common.Constant;
using Battle.Logic.Thing.Extension;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Common.Formula.PresetFunctions
{
    internal class PFProp : TwoArgsPresetFunction
    {
        public override string GetName() {
            return "prop";
        }

        /// <summary>
        /// 获取指定属性
        /// </summary>
        /// <param name="arg1">属性ID</param>
        /// <param name="arg2">目标类型(占位符self, target被替换成0，1)</param>
        /// <returns></returns>
        public override FixedPoint Compute(FixedPoint arg1, FixedPoint arg2) {
            var targetType = (FunctionTargetType)(int)arg2;
            switch (targetType) {
                case FunctionTargetType.Self:
                    return Source.GetPropValue((ThingPropertyType)(int)arg1);
                case FunctionTargetType.Target:
                    return Target.GetPropValue((ThingPropertyType)(int)arg1);
                default:
                    throw new ArgumentOutOfRangeException($"Unhandled functaion target type: {targetType}");
            }
        }
    }
}
