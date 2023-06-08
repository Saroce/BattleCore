//------------------------------------------------------------
//        File:  CastAbilitiesComponent.cs
//       Brief:  CastAbilitiesComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-09
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Combat;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Thing.Component.Ability
{
    [LogicThing]
    public class CastAbilitiesComponent : LogicComponent
    {
        public List<SkillConfData> Value;
    }
}
