//------------------------------------------------------------
//        File:  FormulaUtil.cs
//       Brief:  FormulaUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-27
//============================================================

using System.Collections.Generic;
using Battle.Logic.Common.Formula;
using Battle.Logic.Constant;
using SkillModule.Runtime.Effect;
using SkillModule.Runtime.Formula;
using Core.Lockstep.Math;

namespace Battle.Logic.Utils
{
    public static class FormulaUtil
    {
        public static bool Compute(LogicContexts contexts,
            FormulaData formulaData,
            List<EffectPropOpFormulaParam> formulaArgs,
            LogicThingEntity source,
            LogicThingEntity target,
            out FixedPoint value) {
            
            // TODO 数组GC优化
            var cloneFormulaArgs = new FixedPoint[formulaArgs.Count];
            for (var i = 0; i < formulaArgs.Count; i++) {
                cloneFormulaArgs[i] = formulaArgs[i].ParamValue?.Value ?? 0f;
            }

            var computer = contexts.RefPool<FormulaComputer>().Get();
            computer.Create(contexts, source, target);
            value = computer.Evaluate(formulaData.Formula, cloneFormulaArgs);
            computer.Destroy();
            
            contexts.RefPool<FormulaComputer>().Return(computer);
            return true;
        }
        
        /// <summary>
        /// 计算公式数值
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="formulaId"></param>
        /// <param name="formulaArgs"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Compute(LogicContexts contexts, 
            string formulaId,
            List<EffectPropOpFormulaParam> formulaArgs,
            LogicThingEntity source, 
            LogicThingEntity target, 
            out FixedPoint value) {

            var formulaEntity = contexts.logicEffect.GetEntityWithFormulaId(formulaId);
            if (formulaEntity != null && formulaEntity.hasFormulaData) {
                return Compute(contexts, formulaEntity.formulaData.Value, formulaArgs, source, target, out value);
            }

            value = 0f;
            contexts.LogError(LogTagDef.EffectLogTag, "Formula entity not found, formula id: {0}", formulaId);
            return false;
        }
    }
}