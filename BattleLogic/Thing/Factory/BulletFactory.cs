//------------------------------------------------------------
//        File:  BulletFactory.cs
//       Brief:  BulletFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-11
//============================================================

using Battle.Common.Context.Create;

namespace Battle.Logic.Thing.Factory
{
    public static class BulletFactory
    {
        public static void CreateBullet(this LogicContexts contexts, LogicThingEntity thingEntity,
            BulletCreateContext context) {
            thingEntity.AddCamp(context.CampFlag);
            thingEntity.isBullet = true;
        }
    }
}