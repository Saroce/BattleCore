//------------------------------------------------------------
//        File:  ThingDef.cs
//       Brief:  ThingDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System;

namespace Battle.Common.Constant
{
    public class ThingPropertyDef
    {
        public const int HpCur = 1; // 当前HP
        public const int HpMax = 2; // 最大HP
        public const int Attack = 3; // 攻击力
        public const int PhysicsDefend = 4; // 物理防御力
        public const int MagicDefend = 5; // 法术防御力
        public const int HitRate = 6; // 命中率
        public const int DodgeRate = 7; // 闪避率
        public const int CriticalRate = 8; // 暴击率
        public const int MoveSpeed = 9; // 移动速度
        public const int CastSpeed = 10; // 攻击速度
    }
    
    public enum ThingType
    {
        Unknown,
        Gamer,
        Monster,
        Bullet,
    }
    
    [Flags]
    public enum ThingFlag
    {
        None = 0,
        Static = 1,
        Dynamic = 2
    }

    public enum ThingCastAttributeType
    {
        None,
        Physics,    // 物理
        Magic,      // 魔法
    }

    public enum ThingCastRangeType
    {
        None,
        Melee,  // 近战
        Ranged, // 远程
    }
}