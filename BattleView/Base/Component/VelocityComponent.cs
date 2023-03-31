//------------------------------------------------------------
//        File:  VelocityComponent.cs
//       Brief:  VelocityComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.View.Base.System;
using vFrame.Lockstep.Core;

namespace Battle.View.Base.Component
{
    [ViewThing]
    public class VelocityComponent : ViewComponent
    {
        public TSVector Value;
    }
}