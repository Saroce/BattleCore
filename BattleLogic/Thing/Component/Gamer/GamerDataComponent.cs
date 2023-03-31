//------------------------------------------------------------
//        File:  GamerDataComponent.cs
//       Brief:  GamerDataComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Battle.Common.Context.Combat;
using Battle.Logic.Base.Component;

namespace Battle.Logic.Thing.Component.Gamer
{
    [LogicThing]
    public class GamerInfoComponent : LogicComponent
    {
        public GamerData Value;
    }
}