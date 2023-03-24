//------------------------------------------------------------
//        File:  CommandProcessor.cs
//       Brief:  CommandProcessor
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using System;
using Battle.Common.Context.Command;

namespace Battle.Logic.Input.System
{
    internal  abstract class CommandProcessor<TRequest, TRespond> : LogicContextsBridge, ICommandProcessor
        where TRequest : BattleRequest where TRespond : BattleRespond
    {
        private TRequest _request;
        private TRespond _respond;
        
        public void Process(IBattleRequest request) {
            _request = request as TRequest;
            _respond = request.GetRespond() as TRespond;

            OnProcess(_request, _respond);
        }

        protected abstract void OnProcess(TRequest request, TRespond respond);
        
        public Type GetRequestType() {
            return typeof(TRequest);
        }

        protected void Fail(string message) {
            _respond.Result = false;
            // TODO 错误信息
            _respond.Send();
        }
        
        protected void Succeed() {
            _respond.Result = true;
            _respond.Send();
        }
    }
}
