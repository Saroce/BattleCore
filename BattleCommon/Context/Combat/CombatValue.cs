﻿//------------------------------------------------------------
//        File:  CombatValue.cs
//       Brief:  CombatValue
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using vFrame.Lockstep.Core;

namespace Battle.Common.Context.Combat
{
    public class CombatValue
    {
        public FixedPoint HpCur = 1; // 当前HP
        public FixedPoint HpMax = 2; // 最大HP
        public FixedPoint Attack = 3; // 攻击力
        public FixedPoint PhysicsDefend = 4; // 物理防御力
        public FixedPoint MagicDefend = 5; // 法术防御力
        public FixedPoint HitRate = 6; // 命中率
        public FixedPoint DodgeRate = 7; // 闪避率
        public FixedPoint CriticalRate = 8; // 暴击率
        public FixedPoint MoveSpeed = 9; // 移动速度
        public FixedPoint CastSpeed = 10; // 攻击速度
    }
}