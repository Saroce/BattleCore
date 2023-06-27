//------------------------------------------------------------
//        File:  CombatValueDeltaComponent.cs
//       Brief:  CombatValueDeltaComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Effect.Component
{
    [LogicEffect]
    public class CombatValueDeltaComponent : LogicComponent
    {
        public CombatValue Value;
    }
}
