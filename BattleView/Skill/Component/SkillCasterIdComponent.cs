//------------------------------------------------------------
//        File:  SkillCasterIdComponent.cs
//       Brief:  SkillCasterIdComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.View.Base.Component;
using Entitas.CodeGeneration.Attributes;

namespace Battle.View.Skill.Component
{
    [ViewSkill]
    public class SkillCasterIdComponent : ViewComponent
    {
        [PrimaryEntityIndex]
        public ulong Id;
    }
}