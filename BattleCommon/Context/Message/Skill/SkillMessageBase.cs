//------------------------------------------------------------
//        File:  SkillMessageBase.cs
//       Brief:  SkillMessageBase
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Common.Context.Combat;

namespace Battle.Common.Context.Message.Skill
{
    public class SkillMessageBase<T> : BattleMessage<T> where T : class
    {
        public ulong CasterId { get; set; }
        public SkillConfData SkillConfData { get; set; }
    }
}