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
using Battle.Logic.Common.Event.Formula.PresetFunctions;
using Core.Lite.Base;

namespace Battle.Logic.Common.Event.Formula
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
        }
        
        protected override void OnDestroy() {
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
    }
}
