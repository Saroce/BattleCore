//------------------------------------------------------------
//        File:  HUDHPComponent.cs
//       Brief:  HUDHPComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-01
//============================================================

using Battle.View.Base.Component;

namespace Battle.View.HUD.Component
{
    [ViewHUD]
    public class HUDHPComponent : ViewComponent
    {
        public int Current;
        public int Maximum;
    }
}