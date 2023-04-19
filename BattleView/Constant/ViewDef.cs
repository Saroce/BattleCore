//------------------------------------------------------------
//        File:  ViewDef.cs
//       Brief:  ViewDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-01
//============================================================

using System;
using Battle.Common.Constant;

namespace Battle.View.Constant
{
    public static class ViewConst
    {
        public const string ThingsRootName = "Things";
    }
    
    public enum AvatarBindPointType
    {
        Top,
        Center,
        Bottom,
    }
    
    public static class MotionName
    {
        public const string DefaultLayerName = "Base Layer";

        public static string FromMotion(MotionDef motion) {
            switch (motion) {
                case MotionDef.Idle:
                    return "BattleIdle";
                case MotionDef.Run:
                    return "Run";
                case MotionDef.Dead:
                    return "Die";
                default:
                    throw new ArgumentOutOfRangeException($"Unknown motion: {motion}");
            }
        }
    }
}