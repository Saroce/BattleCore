//------------------------------------------------------------
//        File:  PresetFunction.cs
//       Brief:  PresetFunction
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-26
//============================================================

using System;
using Core.Lite.Base;
using Core.Lockstep.Math;

namespace Battle.Logic.Common.Formula.PresetFunctions
{
    internal abstract class PresetFunction : BaseObject<LogicContexts, LogicThingEntity, LogicThingEntity>
    {
        [Flags]
        protected enum FunctionTargetType
        {
            Self = 0,
            Target = 1,
        }
        
        protected LogicContexts Contexts { get; private set; }
        protected LogicThingEntity Source { get; private set; }
        protected LogicThingEntity Target { get; private set; }
        
        protected override void OnCreate(LogicContexts contexts, LogicThingEntity source, LogicThingEntity target) {
            Contexts = contexts;
            Source = source;
            Target = target;
        }

        protected override void OnDestroy() {
            Contexts = null;
            Source = null;
            Target = null;
        }

        /// <summary>
        /// 对应公式里面的函数名称
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();
    }

    internal abstract class ZeroArgsPresetFunction : PresetFunction
    {
        public abstract FixedPoint Compute();
    }
    
    internal abstract class OneArgsPresetFunction : PresetFunction
    {
        public abstract FixedPoint Compute(FixedPoint arg);
    }

    internal abstract class TwoArgsPresetFunction : PresetFunction
    {
        public abstract FixedPoint Compute(FixedPoint arg1, FixedPoint arg2);
    }
}
