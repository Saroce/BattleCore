//------------------------------------------------------------
//        File:  LogTagDef.cs
//       Brief:  LogTagDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-18
//============================================================

using Core.Lite.Loggers;

namespace Battle.Logic.Constant
{
    internal static class LogTagDef
    {
        public static readonly LogTag ThingLogTag = new LogTag("BattleLogic/Thing");
        public static readonly LogTag SkillLogTag = new LogTag("BattleLogic/Skill");
        public static readonly LogTag InputLogTag = new LogTag("BattleLogic/Input");
    }
}