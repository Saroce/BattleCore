//------------------------------------------------------------
//        File:  ThingFactory.cs
//       Brief:  ThingFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Battle.Common.Context.Create;

namespace Battle.Logic.Thing.Factory
{
    public static class ThingFactory
    {
        public static LogicThingEntity CreateThing(this LogicContexts contexts, ThingCrateContext createContext) {
            var entity = contexts.logicThing.CreateEntity();

            // 基础数据
            entity.AddId(contexts.GetIndependentId());
            entity.AddPosition(createContext.Position);
            entity.AddRotation(createContext.Rotation);
            entity.AddCreateTime(contexts.GetClock().GetTime());

            if (createContext is CreatureCreateContext creatureCreateContext) {
                
            }
            
            return entity;
        }
    }
}