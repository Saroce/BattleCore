//------------------------------------------------------------
//        File:  HUDOwnerComponent.cs
//       Brief:  HUDOwnerComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-01
//============================================================

using Battle.View.Base.Component;
using Entitas.CodeGeneration.Attributes;

namespace Battle.View.HUD.Component
{
    [ViewHUD]
    public class HUDOwnerComponent : ViewComponent
    {
        [EntityIndex]
        public ulong Id;
    }
}