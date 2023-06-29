//------------------------------------------------------------
//        File:  SkillFluxEventContext.cs
//       Brief:  SkillFluxEventContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-17
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Core.Lockstep.Math;
using SkillModule.Runtime.Skill;

namespace Battle.Logic.Skill.Component.Flux
{
    public class SkillFluxEventContext
    {
        public SkillConfData SkillConfData; // 技能配置数据
        public FixedPoint Time; // 触发时间
        public SkillFluxEventType Type; // 技能事件类型
        public ulong SkillEntityId; // 技能实体ID
    }

    public class JudgeFluxEventContext : SkillFluxEventContext
    {
        public ActiveSkillJudge JudgeData;
    }

    public class ShootFluxEventContext : SkillFluxEventContext
    {
        public FluxSkillShootData FluxShootData;
        public ActiveSkillShoot ShootData;
    }
}