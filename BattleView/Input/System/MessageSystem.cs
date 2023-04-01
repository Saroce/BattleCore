﻿//------------------------------------------------------------
//        File:  MessageSystem.cs
//       Brief:  MessageSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using System;
using System.Collections.Generic;
using Battle.View.Base.CSExtension;
using Battle.View.Input.System.Processor;

namespace Battle.View.Input.System
{
    internal class MessageSystem : ViewExecuteSystem
    {
        private readonly Dictionary<Type, IMessageProcessor> _type2Processor;

        public MessageSystem(ViewContexts contexts) : base(contexts) {
            _type2Processor = new Dictionary<Type, IMessageProcessor>();
            
            // TODO 消息注册(考虑利用特性处理)
        }

        private void RegisterProcessor<T>() where T : IMessageProcessor {
            var processor = Activator.CreateInstance<T>();
            processor.Create(Contexts);
            
            _type2Processor.Add(processor.GetMessageType(), processor);
        }
        
        public override void Execute() {
            while (true) {
                if (!Contexts.TryDequeueMessage(out var message)) {
                    break;
                }

                if (_type2Processor.TryGetValue(message.GetType(), out var processor)) {
                    processor.Process(message);
                }
                
                Contexts.GetRefPoolManager().TryReturn(message);
            }
        }
    }
}