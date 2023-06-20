//------------------------------------------------------------
//        File:  SkillFluxEventsComponent.cs
//       Brief:  SkillFluxEventsComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using System.Collections.Generic;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Skill.Component.Flux
{
    [LogicSkill]
    public class SkillFluxEventsComponent : LogicComponent
    {
        public List<SkillFluxEventContext> Value;
    }
}