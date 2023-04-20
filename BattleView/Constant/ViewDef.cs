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
using Battle.View.Base;
using UnityEngine;

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

    public static class AvatarBindPoint
    {
        public static Vector3 GetBindPoint(this BattleViewConfig viewConfig, AvatarBindPointType type) {
            switch (type) {
                case AvatarBindPointType.Top:
                    return viewConfig.AvatarTop;
                case AvatarBindPointType.Center:
                    return viewConfig.AvatarCenter;
                case AvatarBindPointType.Bottom:
                    return viewConfig.AvatarBottom;
                default:
                    throw new ArgumentOutOfRangeException($"Unhandled type:{type}");
            }
        }
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