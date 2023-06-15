//------------------------------------------------------------
//        File:  SkillCastContextComponent.cs
//       Brief:  SkillCastContextComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.Common.Context.Combat;
using Battle.View.Base.Component;

namespace Battle.View.Skill.Component
{
    [ViewSkill]
    public class SkillCastContextComponent : ViewComponent
    {
        public ulong OwnerId;
        public ulong TargetId;
        public SkillConfData Ability;
    }
}