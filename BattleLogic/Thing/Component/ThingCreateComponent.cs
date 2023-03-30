//------------------------------------------------------------
//        File:  ThingCreateComponent.cs
//       Brief:  ThingCreateComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Context.Create;
using Battle.Logic.Base.CSExtension;

namespace Battle.Logic.Thing.Component
{
    [LogicThing]
    public class ThingCreateContextComponent : LogicComponent
    {
        public ThingCrateContext Value;
    }
}
