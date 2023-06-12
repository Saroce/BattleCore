//------------------------------------------------------------
//        File:  GamerFactory.cs
//       Brief:  GamerFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Create;
using Battle.View.Base;
using Battle.View.Constant;
using ExcelConvert.Auto.DressConf;
using ExcelConvert.Auto.GeneralConf;

namespace Battle.View.Thing.Factory
{
    internal static class GamerFactory
    {
        public static void CreateGamer(this ViewContexts contexts, ViewThingEntity entity,
            GamerCreateContext context) {

            var configReader = contexts.GetConfigReader();
            var viewConfig = contexts.GetViewConfig();
            var generalConf = configReader.GetRecord<GeneralConf_General_Record>("GeneralId", context.GeneralId);
            
            entity.AddHealthPoint((int) context.CombatValue.HpCur, (int) context.CombatValue.HpMax);
            
            entity.AddDefaultCastAbility(context.DefSkill);
            if (context.UltSkill != null) {
                entity.AddUltimateCastAbility(context.UltSkill);
            }
            
            // 创建Avatar
            entity.AddAvatarAsset($"{viewConfig.AvatarDir}/{generalConf.Avatar}");
            entity.AddAvatarMotion(MotionName.FromMotion(MotionDef.Idle));
            entity.AddAvatarRadius(generalConf.Radius / 100f);
            
            // 创建血条HUD
            var hpHUD = contexts.viewHUD.CreateEntity();
            hpHUD.AddHUDAsset($"{viewConfig.HUDDir}/{viewConfig.HUDHPPath}");
            hpHUD.AddHUDOwner(entity.id.Value);
            hpHUD.AddHUDHP(entity.healthPoint.Current, entity.healthPoint.Maximun);
            hpHUD.AddHUDPosition(entity.position.Value.ToUnityVector3());
            hpHUD.AddHUDBindPoint(AvatarBindPointType.Top);
            hpHUD.AddHUDOffset(viewConfig.HUDHPOffset);
            hpHUD.isHUDAutoDestroyWithOwner = true;
            hpHUD.isHUDPositionSyncWithOwner = true;
        }
    }
}
