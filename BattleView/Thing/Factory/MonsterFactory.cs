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
using Battle.View.Constant;
using ExcelConvert.Auto.MonsterConf;

namespace Battle.View.Thing.Factory
{
    internal static class MonsterFactory
    {
        public static void CreateMonster(this ViewContexts contexts, ViewThingEntity entity, MonsterCreateContext context) {
            var configReader = contexts.GetConfigReader();
            var viewConfig = contexts.GetViewConfig();

            var monsterConf = configReader.GetRecord<MonsterConf_Monster_Record>("MonsterId", context.MonsterId);
            
            // 创建Avatar
            entity.AddAvatarAsset($"{viewConfig.AvatarDir}/{monsterConf.Avatar}");
            entity.AddAvatarMotion(MotionName.FromMotion(MotionDef.Idle));
            entity.AddAvatarRadius(monsterConf.Radius / 100f);
            
            entity.AddHealthPoint(monsterConf.HP, monsterConf.HP);
        }
    }
}