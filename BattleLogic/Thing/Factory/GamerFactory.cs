//------------------------------------------------------------
//        File:  GamerFactory.cs
//       Brief:  GamerFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Common.Context.Create;

namespace Battle.Logic.Thing.Factory
{
    internal static class GamerFactory
    {
        public static void CreateGamer(this LogicContexts contexts, LogicThingEntity thingEntity,
            GamerCreateContext context) {
            
            // TODO 读取配置表数据

            thingEntity.isGamer = true;
            var combatValue = context.CombatValue;
            
        }
    }
}