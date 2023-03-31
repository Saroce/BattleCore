//------------------------------------------------------------
//        File:  RotationComponent.cs
//       Brief:  RotationComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.View.Base.CSExtension;
using vFrame.Lockstep.Core;

namespace Battle.View.Base.Component
{
    [ViewThing]
    public class RotationComponent : ViewComponent
    {
        public TSQuaternion Value;
    }
}