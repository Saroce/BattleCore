//------------------------------------------------------------
//        File:  SkillCastSpeedScaleComponent.cs
//       Brief:  SkillCastSpeedScaleComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.View.Base.Component;
using vFrame.Lockstep.Core;

namespace Battle.View.Skill.Component
{
    [ViewSkill]
    public class SkillCastSpeedScaleComponent : ViewComponent
    {
        public FixedPoint Value;
    }
}