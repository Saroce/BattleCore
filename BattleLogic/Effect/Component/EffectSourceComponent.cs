//------------------------------------------------------------
//        File:  EffectSourceComponent.cs
//       Brief:  EffectSourceComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using Battle.Common.Constant;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Effect.Component
{
    [LogicEffect]
    public class EffectSourceComponent : LogicComponent
    {
        public EffectSource Value;
    }
}