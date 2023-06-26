//------------------------------------------------------------
//        File:  ThingDef.cs
//       Brief:  ThingDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System;
using vFrame.Lockstep.Core;

namespace Battle.Common.Constant
{
    /// <summary>
    /// 注意与技能编辑器的PropertyDef对应
    /// </summary>
    public enum ThingPropertyType
    {
        None = 0,
        HpCur = 1,                  // 当前HP
        HpMax = 2,                  // 最大HP
        Attack = 3,                 // 攻击力
        PhysicsDefend = 4,          // 物理防御力
        MagicDefend = 5,            // 法术防御力
        HitRate = 6,                // 命中率
        DodgeRate = 7,              // 闪避率
        CriticalRate = 8,           // 暴击率
        MoveSpeed = 9,              // 移动速度
        CastSpeed = 10,             // 攻击速度
    }

    public static class ThingCastSpeed
    {
        public static readonly FixedPoint Default = 1f;
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
        Dynamic = 1 << 1,
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

    public enum ThingOutOfControlType
    {
        None,
        Stun,   // 眩晕
    }
}