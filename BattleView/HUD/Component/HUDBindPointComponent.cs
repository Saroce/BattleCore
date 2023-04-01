//------------------------------------------------------------
//        File:  HUDBindPointComponent.cs
//       Brief:  HUDBindPointComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-01
//============================================================

using Battle.View.Base.Component;
using Battle.View.Constant;

namespace Battle.View.HUD.Component
{
    [ViewHUD]
    public class HUDBindPointComponent : ViewComponent
    {
        public AvatarBindPointType Value;
    }
}