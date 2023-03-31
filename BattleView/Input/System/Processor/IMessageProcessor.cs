//------------------------------------------------------------
//        File:  IMessageProcessor.cs
//       Brief:  IMessageProcessor
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using System;
using Battle.Common.Context.Message;
using Core.Lite.Base;

namespace Battle.View.Input.System.Processor
{
    public interface IMessageProcessor : IBaseObject<ViewContexts>
    {
        void Process(IBattleMessage message);

        Type GetMessageType();
    }
}