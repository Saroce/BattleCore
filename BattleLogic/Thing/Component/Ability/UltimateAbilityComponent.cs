//------------------------------------------------------------
//        File:  UltimateAbilityComponent.cs
//       Brief:  UltimateAbilityComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Thing.Component.Ability
{
    [LogicThing]
    public class UltimateAbilityComponent : LogicComponent
    {
        public SkillConfData Value;
    }
}