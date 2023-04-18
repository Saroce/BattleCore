//------------------------------------------------------------
//        File:  GamerFactory.cs
//       Brief:  GamerFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Create;
using Battle.Logic.Thing.Extension;
using ExcelConvert.Auto.GeneralConf;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Thing.Factory
{
    internal static class GamerFactory
    {
        public static void CreateGamer(this LogicContexts contexts, LogicThingEntity thingEntity,
            GamerCreateContext context) {

            var configReader = contexts.GetController().GetConfigReader();
            var generalConf = configReader.GetRecord<GeneralConf_General_Record>("GeneralId", context.GeneralId);
            
            // TODO 
            
            thingEntity.isGamer = true;
            thingEntity.AddRadius((FixedPoint) generalConf.Radius / 100f);
            thingEntity.AddThingCastAttributeType((ThingCastAttributeType) generalConf.GeneralType1);
            thingEntity.AddThingCastRangeType((ThingCastRangeType) generalConf.GeneralType2);
            
            var combatValue = context.CombatValue;
            thingEntity.SetPropertiesFromCombatValue(combatValue);
            
            // TODO 技能配置
            
            // TODO AI行为
        }
    }
}