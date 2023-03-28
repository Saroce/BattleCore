//------------------------------------------------------------
//        File:  GamerCombatComponent.cs
//       Brief:  GamerCombatComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Base.CSExtension;

namespace Battle.Logic.Thing.Component.Gamer
{
    [LogicThing]
    public class GamerCombatComponent : LogicComponent
    {
        public CombatValue Value;
    }
}