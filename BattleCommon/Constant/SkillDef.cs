//------------------------------------------------------------
//        File:  SkillDef.cs
//       Brief:  SkillDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-08
//============================================================

namespace Battle.Common.Constant
{
    public static class SkillDef
    {
        /// <summary>
        /// 技能配置目录
        /// </summary>
        public const string SkillDataDir = "Assets/Bundles/Data/Skills/";
    }

    public enum SkillCastResult
    {
        NoError,    // 无错误
        NotCastableState, // 非可施法状态
        CastStateRejected, // 施法状态拒绝
        PassiveSkillNotCastable, // 被动技能无法施放
        NoValidTarget,  // 无有效目标
        TargetIsDead, // 目标死亡
        TargetTooFar, // 目标太远
        TargetSelectNoMatch, // 目标选择不匹配
    }
}