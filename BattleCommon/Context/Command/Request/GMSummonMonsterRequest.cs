//------------------------------------------------------------
//        File:  GMSummonMonsterRequest.cs
//       Brief:  GMSummonMonsterRequest
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-10
//============================================================

using System;
using Battle.Common.Context.Command.Respond;
using Core.Lockstep.Math;

namespace Battle.Common.Context.Command.Request
{
    public class GMSummonMonsterRequest : BattleRequest
    {
        public int MonsterId;

        public TSVector Position = TSVector.zero;

        public TSQuaternion Rotation = TSQuaternion.identity;
        
        public GMSummonMonsterRequest() : base(typeof(DefaultRespond)) {
            
        }
    }
}