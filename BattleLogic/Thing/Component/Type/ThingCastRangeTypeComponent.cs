//------------------------------------------------------------
//        File:  ThingCastRangeTypeComponent.cs
//       Brief:  ThingCastRangeTypeComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-30
//============================================================

using Battle.Common.Constant;
using Battle.Logic.Base.Component;
using Battle.Logic.Base.CSExtension;

namespace Battle.Logic.Thing.Component.Type
{
    [LogicThing]
    public class ThingCastRangeTypeComponent : LogicComponent
    {
        public ThingCastRangeType Value;
    }
}