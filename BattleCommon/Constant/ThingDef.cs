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
    public enum ThingPropertyType
    {
        None,
        HpCur,                  // 当前HP
        HpMax,                  // 最大HP
        Attack,                 // 攻击力
        PhysicsDefend,          // 物理防御力
        MagicDefend,            // 法术防御力
        HitRate,                // 命中率
        DodgeRate,              // 闪避率
        CriticalRate,           // 暴击率
        MoveSpeed,              // 移动速度
        CastSpeed               // 攻击速度
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

    public enum ThingOutOfControlType
    {
        None,
        Stun,   // 眩晕
    }
}