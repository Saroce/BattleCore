//------------------------------------------------------------
//        File:  SkillCasterIdComponent.cs
//       Brief:  SkillCasterIdComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.Logic.Base.Component;

namespace Battle.Logic.Skill.Component.Cast
{
    [LogicSkill]
    public class SkillCasterIdComponent : LogicComponent
    {
        public ulong Value;
    }
}