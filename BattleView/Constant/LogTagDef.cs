//------------------------------------------------------------
//        File:  LogTagDef.cs
//       Brief:  LogTagDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-20
//============================================================

using Core.Lite.Loggers;

namespace Battle.View.Constant
{
    internal static class LogTagDef
    {
        public static readonly LogTag InputLogTag = new LogTag("BattleView/Input");
        public static readonly LogTag ThingLogTag = new LogTag("BattleView/Thing");
        public static readonly LogTag HUDLogTag = new LogTag("BattleView/HUD");
    }
}