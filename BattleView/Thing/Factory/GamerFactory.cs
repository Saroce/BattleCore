//------------------------------------------------------------
//        File:  GamerFactory.cs
//       Brief:  GamerFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Context.Create;
using ExcelConvert.Auto.DressConf;
using ExcelConvert.Auto.GeneralConf;

namespace Battle.View.Thing.Factory
{
    internal static class GamerFactory
    {
        public static void CreateGamer(this ViewContexts contexts, ViewThingEntity thingEntity,
            GamerCreateContext context) {

            var configReader = contexts.GetConfigReader();
            var viewConfig = contexts.GetViewConfig();
            var generalConf = configReader.GetRecord<GeneralConf_General_Record>("GeneralId", context.GeneralId);
            
            thingEntity.AddHealthPoint((int) context.CombatValue.HpCur, (int) context.CombatValue.HpMax);
            
            // TODO 添加技能配置
            
            // 创建Avatar
            thingEntity.AddAvatarAsset($"{viewConfig.AvatarDir}/{generalConf.Avatar}");
        }
    }
}
