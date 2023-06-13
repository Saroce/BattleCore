//------------------------------------------------------------
//        File:  CastSkillRequest.cs
//       Brief:  CastSkillRequest
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using System;
using Battle.Common.Context.Command.Respond;

namespace Battle.Common.Context.Command.Request
{
    public class CastSkillRequest : BattleRequest, IRecordableRequest
    {
        public ulong Id { get; set; } // 逻辑实体Id
        
        public CastSkillRequest() : base(typeof(DefaultRespond)) {
            
        }
    }
}