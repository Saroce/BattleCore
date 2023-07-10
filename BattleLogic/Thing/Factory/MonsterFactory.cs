//------------------------------------------------------------
//        File:  MonsterFactory.cs
//       Brief:  MonsterFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-10
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Create;
using Battle.Logic.Thing.Extension;
using Battle.Logic.Utils;
using Core.Lockstep.Math;
using ExcelConvert.Auto.MonsterConf;

namespace Battle.Logic.Thing.Factory
{
    internal static class MonsterFactory
    {
        public static void CreateMonster(this LogicContexts contexts, LogicThingEntity thingEntity,
            MonsterCreateContext context) {

            var configReader = contexts.GetController().GetConfigReader();
            var monsterConf = configReader.GetRecord<MonsterConf_Monster_Record>("MonsterId", context.MonsterId);

            thingEntity.isMonster = true;
            
            // 基础属性
            thingEntity.AddRadius((FixedPoint) monsterConf.Radius / 100f);
            thingEntity.AddThingCastAttributeType((ThingCastAttributeType)monsterConf.MonsterType1);
            thingEntity.AddThingCastRangeType((ThingCastRangeType)monsterConf.MonsterType2);
            
            // 战斗属性
            var combatValue = ConfigUtil.ReadCombatValue(monsterConf);
            thingEntity.SetPropertiesFromCombatValue(combatValue);
            
            // 施法能力
            contexts.ReadAbilities(thingEntity,
                monsterConf.DefaultSkill,
                monsterConf.Skill01,
                monsterConf.DefaultSkill,
                monsterConf.Skill01,
                monsterConf.Skill02
                );
            
            // TODO AI
        }
    }
}