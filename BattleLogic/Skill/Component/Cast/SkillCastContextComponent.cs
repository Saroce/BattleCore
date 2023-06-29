//------------------------------------------------------------
//        File:  SkillCastContextComponent.cs
//       Brief:  SkillCastContextComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Base.Component;
using Core.Lockstep.Math;

namespace Battle.Logic.Skill.Component.Cast
{
    [LogicSkill]
    public class SkillCastContextComponent : LogicComponent
    {
        public ulong CasterId;
        public ulong TargetId;
        public SkillConfData Ability;
        public FixedPoint CastSpeed;
    }
}