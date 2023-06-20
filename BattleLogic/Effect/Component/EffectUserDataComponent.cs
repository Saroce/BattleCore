//------------------------------------------------------------
//        File:  EffectUserDataComponent.cs
//       Brief:  EffectUserDataComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Effect.Component
{
    [LogicEffect]
    public class EffectUserDataComponent : LogicComponent
    {
        public EffectUserData Value;
    }
}