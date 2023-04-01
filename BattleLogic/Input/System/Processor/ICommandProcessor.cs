//------------------------------------------------------------
//        File:  ICommandProcessor.cs
//       Brief:  ICommandProcessor
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

using System;
using Battle.Common.Context.Command;
using Core.Lite.Base;

namespace Battle.Logic.Input.System.Processor
{
    internal interface ICommandProcessor : IBaseObject<LogicContexts>
    {
        void Process(IBattleRequest request);

        Type GetRequestType();
    }
}
