//------------------------------------------------------------
//        File:  PositionComponent.cs
//       Brief:  PositionComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.View.Base.System;
using Core.Lockstep.Math;

namespace Battle.View.Base.Component
{
    [ViewThing]
    public class PositionComponent : ViewComponent
    {
        public TSVector Value;
    }
}