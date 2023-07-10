//------------------------------------------------------------
//        File:  CampComponent.cs
//       Brief:  CampComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-10
//============================================================

using Battle.Common.Constant;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Thing.Component.Property.Base
{
    [LogicThing]
    public class CampComponent : LogicComponent
    {
        public CampFlag Value;
    }
}