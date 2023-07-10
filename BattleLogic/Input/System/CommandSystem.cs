//------------------------------------------------------------
//        File:  CommandSystem.cs
//       Brief:  CommandSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using System;
using System.Collections.Generic;
using Battle.Logic.Base.System;
using Battle.Logic.Constant;
using Battle.Logic.Input.System.Processor;
using Battle.Logic.Input.System.Processor.GM;

namespace Battle.Logic.Input.System
{
    // TODO 处理回放的命令
    internal class CommandSystem : LogicBaseSystem
    {
        private readonly Dictionary<Type, ICommandProcessor> _processors;

        public CommandSystem(LogicContexts contexts) : base(contexts) {
            _processors = new Dictionary<Type, ICommandProcessor>();
            
            RegisterProcessor<CastSkill>();
            RegisterProcessor<RetrieveGamerByGeneralId>();
            
            RegisterProcessor<GMSummonMonster>();
        }

        private void RegisterProcessor<T>() where T : ICommandProcessor {
            var processor = Activator.CreateInstance<T>();
            processor.Create(Contexts);
            
            _processors.Add(processor.GetRequestType(), processor);
        }

        internal void Execute() {
            ProcessCommandQueue();
        }
        
        /// <summary>
        /// 处理命令队列里缓存的命令
        /// </summary>
        private void ProcessCommandQueue() {
            while (true) {
                if (!Contexts.TryDequeueRequest(out var request)) {
                    break;
                }

                if (!_processors.TryGetValue(request.GetType(), out var processor)) {
                    LogError(LogTagDef.InputLogTag, "No command processor registered for type: {0}", request.GetType().Name);
                    continue;
                }
                
                processor.Process(request);
            }
        }
    }
}