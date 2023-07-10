//------------------------------------------------------------
//        File:  CampDef.cs
//       Brief:  CampDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-10
//============================================================

using System;

namespace Battle.Common.Constant
{
    [Flags]
    public enum CampFlag
    {
        Camp_0 = 0,         // 中立
        Camp_1 = 1,         // 玩家
        Camp_2 = 1 << 1     // 怪物（PVE），或者敌方（PVP）
    }
}