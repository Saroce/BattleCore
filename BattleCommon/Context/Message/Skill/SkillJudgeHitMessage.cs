//------------------------------------------------------------
//        File:  SkillJudgeHitMessage.cs
//       Brief:  SkillJudgeHitMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using System.Collections.Generic;
using SkillModule.Runtime.Skill;

namespace Battle.Common.Context.Message.Skill
{
    public class SkillJudgeHitMessage : SkillMessageBase<SkillJudgeHitMessage>
    {
        public List<ulong> Targets { get; set; }
        public ActiveSkillEffectData EffectData { get; set; }
    }
}