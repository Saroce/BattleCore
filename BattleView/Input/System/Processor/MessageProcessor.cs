//------------------------------------------------------------
//        File:  MessageProcessor.cs
//       Brief:  MessageProcessor
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using System;
using Battle.Common.Context.Message;

namespace Battle.View.Input.System.Processor
{
    internal abstract class MessageProcessor<TMessage> : ViewContextsBridge, IMessageProcessor
        where TMessage : class, IBattleMessage
    {
        public void Process(IBattleMessage message) {
            OnProcess(message as TMessage);
        }

        protected abstract void OnProcess(TMessage message);

        public Type GetMessageType() {
            return typeof(TMessage);
        }
    }
}