//------------------------------------------------------------
//        File:  ThingFactory.cs
//       Brief:  ThingFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using System;
using Battle.Common.Constant;
using Battle.Common.Context.Create;
using Battle.Common.Context.Message.Thing;

namespace Battle.View.Thing.Factory
{
    internal static class ThingFactory
    {
        public static void CreateThing(this ViewContexts contexts, ThingCreateMessage message) {
            var entity = contexts.viewThing.CreateEntity();
            
            // Base
            entity.AddId(message.Id);
            entity.AddCreateContext(message.CreateContext);
            entity.AddThingType(message.ThingType);
            entity.AddPosition(message.CreateContext.Position);
            entity.AddRotation(message.CreateContext.Rotation);

            if (message.CreateContext is CreatureCreateContext creatureCreateContext) {
                entity.AddCampFlag(creatureCreateContext.CampFlag);
            }
            
            switch (message.ThingType) {
                case ThingType.Gamer:
                    contexts.CreateGamer(entity, message.CreateContext as GamerCreateContext);
                    break;
                case ThingType.Monster:
                    contexts.CreateMonster(entity, message.CreateContext as MonsterCreateContext);
                    break;
                case ThingType.Bullet:
                    // TODO 
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unknown thing type: {message.ThingType}");
            }
        }
    }
}
