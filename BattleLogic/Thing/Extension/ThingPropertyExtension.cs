﻿//------------------------------------------------------------
//        File:  ThingPropertyExtension.cs
//       Brief:  ThingPropertyExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using System;
using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Thing.Extension
{
    internal static class ThingPropertyExtension
    {
        public static void SetPropValue(this LogicThingEntity thingEntity, ThingPropertyType propType, FixedPoint newValue) {
            switch (propType) {
                case ThingPropertyType.HpCur:
                    var max = thingEntity.hasHealPoint ? thingEntity.healPoint.Maximum : 0;
                    thingEntity.ReplaceHealPoint(newValue, max);
                    break;
                case ThingPropertyType.HpMax:
                    var curValue = thingEntity.hasHealPoint ? thingEntity.healPoint.Current : 0;
                    thingEntity.ReplaceHealPoint(curValue, newValue);
                    break;
                case ThingPropertyType.Attack:
                    thingEntity.ReplaceAttack(newValue);
                    break;
                case ThingPropertyType.PhysicsDefend:
                    thingEntity.ReplacePhysicsDefend(newValue);
                    break;
                case ThingPropertyType.MagicDefend:
                    thingEntity.ReplaceMagicDefend(newValue);
                    break;
                case ThingPropertyType.HitRate:
                    thingEntity.ReplaceHitRate(newValue);
                    break;
                case ThingPropertyType.DodgeRate:
                    thingEntity.ReplaceDodgeRate(newValue);
                    break;
                case ThingPropertyType.CriticalRate:
                    thingEntity.ReplaceCriticalRate(newValue);
                    break;
                case ThingPropertyType.MoveSpeed:
                    thingEntity.ReplaceMoveSpeed(newValue);
                    break;
                case ThingPropertyType.CastSpeed:
                    thingEntity.ReplaceCastSpeed(newValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Set property failed, Unknown type: {propType}");
            }
        }

        public static FixedPoint GetPropValue(this CombatValue combatValue, ThingPropertyType propType) {
            switch (propType) {
                case ThingPropertyType.HpCur:
                    return combatValue.HpCur;
                case ThingPropertyType.HpMax:
                    return combatValue.HpMax;
                case ThingPropertyType.Attack:
                    return combatValue.Attack;
                case ThingPropertyType.PhysicsDefend:
                    return combatValue.PhysicsDefend;
                case ThingPropertyType.MagicDefend:
                    return combatValue.MagicDefend;
                case ThingPropertyType.HitRate:
                    return combatValue.HitRate;
                case ThingPropertyType.DodgeRate:
                    return combatValue.DodgeRate;
                case ThingPropertyType.CriticalRate:
                    return combatValue.CriticalRate;
                case ThingPropertyType.MoveSpeed:
                    return combatValue.MoveSpeed;
                case ThingPropertyType.CastSpeed:
                    return combatValue.CastSpeed;
                default:
                    throw new ArgumentOutOfRangeException($"Get property failed, Unknown type: {propType}");
            }
        }
        
        public static void ReadPropertiesFromCombatValue(this LogicThingEntity thingEntity, CombatValue combatValue) {
            thingEntity.SetPropValue(ThingPropertyType.HpCur, combatValue.HpCur);
            thingEntity.SetPropValue(ThingPropertyType.HpMax, combatValue.HpMax);
            thingEntity.SetPropValue(ThingPropertyType.Attack, combatValue.Attack);
            thingEntity.SetPropValue(ThingPropertyType.PhysicsDefend, combatValue.PhysicsDefend);
            thingEntity.SetPropValue(ThingPropertyType.MagicDefend, combatValue.MagicDefend);
            thingEntity.SetPropValue(ThingPropertyType.HitRate, combatValue.HitRate);
            thingEntity.SetPropValue(ThingPropertyType.DodgeRate, combatValue.DodgeRate);
            thingEntity.SetPropValue(ThingPropertyType.CriticalRate, combatValue.CriticalRate);
            thingEntity.SetPropValue(ThingPropertyType.MoveSpeed, combatValue.MoveSpeed);
            thingEntity.SetPropValue(ThingPropertyType.CastSpeed, combatValue.CastSpeed);
        }
    }
}