//------------------------------------------------------------
//        File:  FormulaIdComponent.cs
//       Brief:  FormulaIdComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-27
//============================================================

using Battle.Logic.Base.Component;
using Entitas.CodeGeneration.Attributes;

namespace Battle.Logic.Effect.Component
{
    [LogicEffect]
    public class FormulaIdComponent : LogicComponent
    {
        [PrimaryEntityIndex]
        public string Value;
    }
}