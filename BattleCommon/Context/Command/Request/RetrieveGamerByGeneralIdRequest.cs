//------------------------------------------------------------
//        File:  RetrieveGamerByGeneralIdRequest.cs
//       Brief:  RetrieveGamerByGeneralIdRequest
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-08
//============================================================

using System;
using Battle.Common.Context.Command.Respond;

namespace Battle.Common.Context.Command.Request
{
    public class RetrieveGamerByGeneralIdRequest : BattleRequest
    {
        public int GeneralId { get; set; }  // 武将Id

        public RetrieveGamerByGeneralIdRequest() : base(typeof(RetrieveGamerByGeneralIdRespond)) {
            
        }
    }
}
