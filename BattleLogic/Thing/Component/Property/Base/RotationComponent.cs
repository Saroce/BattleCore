//------------------------------------------------------------
//        File:  RotationComponent.cs
//       Brief:  RotationComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Battle.Logic.Base.CSExtension;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Thing.Component.Property.Base
{
    [LogicThing]
    public class RotationComponent : LogicComponent
    {
        public TSQuaternion Value;
    }
}