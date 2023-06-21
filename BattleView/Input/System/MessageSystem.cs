//------------------------------------------------------------
//        File:  MessageSystem.cs
//       Brief:  MessageSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using System;
using System.Collections.Generic;
using Battle.View.Base.System;
using Battle.View.Input.System.Processor;

namespace Battle.View.Input.System
{
    internal class MessageSystem : ViewExecuteSystem
    {
        private readonly Dictionary<Type, IMessageProcessor> _type2Processor;

        public MessageSystem(ViewContexts contexts) : base(contexts) {
            _type2Processor = new Dictionary<Type, IMessageProcessor>();
            
            // 物体相关消息
            RegisterProcessor<OnCreateThing>();
            RegisterProcessor<OnPositionUpdate>();
            RegisterProcessor<OnRotationUpdate>();
            RegisterProcessor<OnEnterIdle>();
            RegisterProcessor<OnEnterCast>();
            
            // 技能相关消息
            RegisterProcessor<OnSkillJudgeHit>();
        }

        /// <summary>
        /// 注册消息处理器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private void RegisterProcessor<T>() where T : IMessageProcessor {
            var processor = Activator.CreateInstance<T>();
            processor.Create(Contexts);
            
            _type2Processor.Add(processor.GetMessageType(), processor);
        }
        
        /// <summary>
        /// 渲染帧处理消息队列里缓存的消息
        /// </summary>
        public override void Execute() {
            while (true) {
                if (!Contexts.TryDequeueMessage(out var message)) {
                    break;
                }

                if (_type2Processor.TryGetValue(message.GetType(), out var processor)) {
                    processor.Process(message);
                }
                
                Contexts.RefPoolManager().TryReturn(message);
            }
        }
    }
}