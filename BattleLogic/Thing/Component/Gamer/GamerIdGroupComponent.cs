//------------------------------------------------------------
//        File:  GamerIdGroupComponent.cs
//       Brief:  GamerIdGroupComponent
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using System.Collections.Generic;
using Battle.Logic.Base.CSExtension;

namespace Battle.Logic.Thing.Component.Gamer
{
    [LogicThing]
    public class GamerIdGroupComponent : LogicComponent
    {
        /// <summary>
        /// 缓存所有玩家Id
        /// </summary>
        public List<ulong> Value;
    }
}