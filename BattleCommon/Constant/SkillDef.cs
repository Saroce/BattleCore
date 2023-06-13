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
        PassiveSkillNotCastable, // 被动技能无法施放
    }
}