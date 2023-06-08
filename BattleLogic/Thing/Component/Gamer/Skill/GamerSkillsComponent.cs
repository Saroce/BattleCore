//------------------------------------------------------------
//        File:  GamerSkillsComponent.cs
//       Brief:  GamerSkillsComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Combat;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Thing.Component.Gamer.Skill
{
    [LogicThing]
    public class GamerSkillsComponent : LogicComponent
    {
        public List<SkillConfData> Value;
    }
}