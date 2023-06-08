//------------------------------------------------------------
//        File:  PassiveAbilitiesComponent.cs
//       Brief:  PassiveAbilitiesComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Combat;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Thing.Component.Ability
{
    [LogicThing]
    public class PassiveAbilitiesComponent : LogicComponent
    {
        public List<SkillConfData> Value = new List<SkillConfData>();
    }
}