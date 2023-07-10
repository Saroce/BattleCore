//------------------------------------------------------------
//        File:  ThingFactory.cs
//       Brief:  逻辑实体物件工厂
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using System;
using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Common.Context.Create;
using Battle.Common.Context.Message.Thing;
using Battle.Logic.Thing.Extension;

namespace Battle.Logic.Thing.Factory
{
    internal static class ThingFactory
    {
        public static LogicThingEntity CreateThing(this LogicContexts contexts, ThingCrateContext createContext) {
            var entity = contexts.logicThing.CreateEntity();
            
            entity.AddId(contexts.GetIndependentId());
            entity.AddPosition(createContext.Position);
            entity.AddRotation(createContext.Rotation);
            entity.AddCreateTime(contexts.GetClock().GetTime());

            if (createContext is CreatureCreateContext creatureCreateContext) {
                contexts.CreateCreature(entity, creatureCreateContext);
            }

            switch (createContext.ThingType) {
                case ThingType.Gamer:
                    contexts.CreateGamer(entity, createContext as GamerCreateContext);
                    break;
                case ThingType.Monster:
                    contexts.CreateMonster(entity, createContext as MonsterCreateContext);
                    break;
                case ThingType.Bullet:
                    // TODO
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown thing type: {createContext.ThingType}");
            }
            
            entity.AddThingCreateContext(createContext);
            entity.isThing = true;

            var message = contexts.RefPool<ThingCreateMessage>().Get();
            message.Id = entity.id.Value;
            message.ThingType = entity.GetThingType();
            message.CreateContext = entity.thingCreateContext.Value;
            contexts.SendMessage(message);

            // 切换到Idle状态
            entity.Idle(contexts, false);
            
            return entity;
        }
    }
}