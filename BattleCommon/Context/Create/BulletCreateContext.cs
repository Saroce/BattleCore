//------------------------------------------------------------
//        File:  BulletCreateContext.cs
//       Brief:  BulletCreateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-11
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Combat;

namespace Battle.Common.Context.Create
{
    public class BulletCreateContext : ThingCrateContext
    {
        public FluxSkillShootData ShootData;
        public CampFlag CampFlag;

        public BulletCreateContext() {
            ThingType = ThingType.Bullet;
        }
    }
}