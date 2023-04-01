//------------------------------------------------------------
//        File:  CreateContextComponent.cs
//       Brief:  CreateContextComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Context.Create;
using Battle.View.Base.System;

namespace Battle.View.Thing.Component
{
    [ViewThing]
    public class CreateContextComponent : ViewComponent
    {
        public ThingCrateContext Value;
    }
}