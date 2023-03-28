//------------------------------------------------------------
//        File:  ThingCrateContext.cs
//       Brief:  ThingCrateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Battle.Common.Constant;
using vFrame.Lockstep.Core;

namespace Battle.Common.Context.Create
{
    public class ThingCrateContext
    {
        public ThingFlag ThingFlag = ThingFlag.Dynamic;
        public TSVector Position = TSVector.zero;
        public TSQuaternion Rotation = TSQuaternion.identity;
        public ThingType ThingType = ThingType.Unknown;
    }
}