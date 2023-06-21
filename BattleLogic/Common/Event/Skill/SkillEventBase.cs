//------------------------------------------------------------
//        File:  SkillEventBase.cs
//       Brief:  SkillEventBase
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Base.Event;

namespace Battle.Logic.Common.Event.Skill
{
    internal class SkillEventBase : IEventContext
    {
        public ulong EntityId { get; set; } // 技能实体ID
        public ulong CasterId { get; set; } // 施法者ID
        public ulong TargetId { get; set; } // 目标ID
        public SkillConfData SkillConfData { get; set; } // 技能配置
    }
}