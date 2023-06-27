//------------------------------------------------------------
//        File:  EffectDef.cs
//       Brief:  EffectDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

namespace Battle.Common.Constant
{
    public static class EffectDef
    {
        public const string FormulaDataFilePath = "Assets/Bundles/Data/Formulas/FormulaConf.json"; // 公式数据配置路径
    }

    public enum EffectSource
    {
        Skill,
        PassiveSkill,
        Buff
    }
}