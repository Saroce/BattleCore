//------------------------------------------------------------
//        File:  FormulaPreprocessor.cs
//       Brief:  FormulaPreprocessor
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-26
//============================================================

using System.Collections.Generic;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Common.Formula
{
    internal static class FormulaPreprocessor
    {
        private static readonly object LockObject = new object();
        private static readonly Dictionary<string, string> Formulas = new Dictionary<string, string>();

        // 占位符，需要跟PropFunctionTargetType位置对应
        private static readonly List<string> Placeholders = new List<string> {
            "self", "target",
        };

        /// <summary>
        /// 公式预处理
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Process(string formula, FixedPoint[] args) {
            formula = TransferPlaceholders(formula);
            formula = FulfillParams(formula, args);
            return formula;
        }

        /// <summary>
        /// 占位符处理
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        private static string TransferPlaceholders(string formula) {
            lock (LockObject) {
                if (Formulas.TryGetValue(formula, out var ret)) {
                    return ret;
                }

                ret = formula;
                for (var i = 0; i < Placeholders.Count; i++) {
                    ret = ret.Replace(Placeholders[i], i.ToString());
                }
                Formulas.Add(formula, ret);
                return ret;
            }
        }

        /// <summary>
        /// 参数填充, 将公式里面的{0}, {1} ... 替换具体数值，例如属性ID，整形数据，或各种类型
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static string FulfillParams(string formula, FixedPoint[] args) {
            if (args == null || args.Length <= 0) {
                return formula;
            }

            for (var i = 0; i < args.Length; i++) {
                formula = formula.Replace($"{{{i}}}", args[i].ToString());
            }
            return formula;
        }
    }
}
