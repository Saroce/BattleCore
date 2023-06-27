//------------------------------------------------------------
//        File:  FormulaComputer.cs
//       Brief:  FormulaComputer
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-26
//============================================================

using System;
using System.Collections.Generic;
using Battle.Logic.Base.ShuntingYardAlgorithm;
using Battle.Logic.Common.Formula.PresetFunctions;
using Battle.Logic.Constant;
using Core.Lite.Base;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Common.Formula
{
    internal class FormulaComputer : BaseObject<LogicContexts, LogicThingEntity, LogicThingEntity>
    {
        private LogicContexts _contexts;
        private LogicThingEntity _source;
        private LogicThingEntity _target;

        private Dictionary<Type, PresetFunction> _presets;
        private Function _function;

        protected override void OnCreate(LogicContexts contexts, LogicThingEntity source, LogicThingEntity target) {
            _contexts = contexts;
            _source = source;
            _target = target;

            _presets = contexts.DictionaryPool<Type, PresetFunction>().Get();

            _function = contexts.RefPool<Function>().Get();
            _function.Reset();

            AddPresetFunctions();
        }
        
        protected override void OnDestroy() {
            RemovePresetFunctions();
            
            if (null != _presets) {
                _contexts.DictionaryPool<Type, PresetFunction>().Return(_presets);
                _presets = null;
            }

            if (null != _function) {
                _contexts.RefPool<Function>().Return(_function);
                _function = null;
            }

            _contexts = null;
            _source = null;
            _target = null;
        }

        private void AddPresetFunctions() {
            AddPresetFunction<PFProp>();
        }

        private void RemovePresetFunctions() {
            RemovePresetFunction<PFProp>();
        }
        
        private void AddPresetFunction<T>() where T : PresetFunction, new() {
            var presetFunc = _contexts.RefPool<T>().Get();
            presetFunc.Create(_contexts, _source, _target);

            switch (presetFunc) {
                case ZeroArgsPresetFunction zeroArgsPresetFunction:
                    _function.RegisterZeroArgsDelegate(zeroArgsPresetFunction.GetName(), zeroArgsPresetFunction.Compute);
                    break;
                case OneArgsPresetFunction oneArgPresetFunction:
                    _function.RegisterOneArgsDelegate(oneArgPresetFunction.GetName(), oneArgPresetFunction.Compute);
                    break;
                case TwoArgsPresetFunction twoArgsPresetFunction:
                    _function.RegisterTwoArgsDelegate(twoArgsPresetFunction.GetName(), twoArgsPresetFunction.Compute);
                    break;
            }
            
            // 添加公式里面函数名称与TokenType的映射
            Token.AddCustomToken(presetFunc.GetName(), TokenType.Function);
            _presets.Add(typeof(T), presetFunc);
        }

        private void RemovePresetFunction<T>() where T : PresetFunction, new() {
            var type = typeof(T);
            if (!_presets.ContainsKey(type)) {
                return;
            }
            
            var presetFunc = _presets[type];
            switch (presetFunc) {
                case ZeroArgsPresetFunction zeroArgPresetFunction:
                    _function.UnregisterZeroArgDelegate(zeroArgPresetFunction.GetName());
                    break;
                case OneArgsPresetFunction oneArgPresetFunction:
                    _function.UnregisterOneArgsDelegate(oneArgPresetFunction.GetName());
                    break;
                case TwoArgsPresetFunction twoArgsPresetFunction:
                    _function.UnregisterTwoArgsDelegate(twoArgsPresetFunction.GetName());
                    break;
            }
            presetFunc.Destroy();
            
            _contexts.RefPool<T>().Return(presetFunc as T);
            _presets.Remove(type);
        }

        /// <summary>
        /// 公式求值
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public FixedPoint Evaluate(string formula, FixedPoint[] args) {
            // 先对公式进行预处理将占位符进行替换，参数进行填充
            formula = FormulaPreprocessor.Process(formula, args);
            
            // 词法分析公式，拆分为Tokens列表
            var tokens = Lexer.Tokenize(_contexts, formula);
            // 中缀转后缀
            var algorithm = new ShuntingYard(_contexts, tokens);
            // 后缀求值
            try {
                var evaluator = new Evaluator(_contexts, algorithm.PostfixTokens, _function);
                var value = evaluator.Evaluate();
                return value;
            }
            catch (Exception e) {
                _contexts.LogError(LogTagDef.EffectLogTag, "Formula evaluate error: {0}, formula: {1}", e.Message,
                    formula);
                return 0;
            }
        }
    }
}
