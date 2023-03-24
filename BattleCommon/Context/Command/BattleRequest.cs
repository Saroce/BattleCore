//------------------------------------------------------------
//        File:  BattleRequest.cs
//       Brief:  BattleRequest
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using System;

namespace Battle.Common.Context.Command
{
    public abstract class BattleRequest : IBattleRequest
    {
        private readonly IBattleRespond _respond;

        protected BattleRequest(Type respond) {
            _respond = Activator.CreateInstance(respond) as IBattleRespond;
        }

        public IBattleRespond GetRespond() => _respond;
    }
}