//------------------------------------------------------------
//        File:  LogicReactiveSystem.cs
//       Brief:  LogicReactiveSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using System.Collections.Generic;
using System.Diagnostics;
using Battle.Common.Context.Message;
using Battle.Logic.Base.Event;
using Core.Lite.DataSystem;
using Core.Lite.DataSystem.Config;
using Core.Lite.Loggers;
using Core.Lite.RefPool;
using Entitas;

namespace Battle.Logic.Base.System
{
    internal abstract class LogicReactiveSystem<TEntity> : ReactiveSystem<TEntity> where TEntity : class, IEntity
    {
        protected LogicContexts Contexts { get; }

        protected LogicReactiveSystem(LogicContexts contexts, IContext<TEntity> context) : base(context) {
            Contexts = contexts;
        }

        protected abstract override ICollector<TEntity> GetTrigger(IContext<TEntity> context);

        protected abstract override bool Filter(TEntity entity);

        protected abstract override void Execute(List<TEntity> entities);
        
        protected IConfigReader ConfigReader => Contexts.GetController().GetConfigReader();
        protected IDataReader DataReader => Contexts.GetBattleContext().DataReader;
        
        protected void SendMessage(IBattleMessage message) {
            Contexts.SendMessage(message);
        }
        
        protected void SendEvent(IEventContext context) {
            Contexts.SendEvent(context);
        }
        
        public IRefPool<List<T>> ListPool<T>() {
            return Contexts.ListPool<T>();
        }
        
        // [Conditional("FULL_LOG")]
        protected void LogDebug(LogTag tag, string content, params object[] args) {
            Contexts.GetLogger().LogDebug(tag, content, 2, args);
        }

        protected void LogInfo(LogTag tag, string content, params object[] args) {
            Contexts.GetLogger().LogInfo(tag, content, 2, args);
        }

        protected void LogWarning(LogTag tag, string content, params object[] args) {
            Contexts.GetLogger().LogWarning(tag, content, 2, args);
        }

        protected void LogError(LogTag tag, string content, params object[] args) {
            Contexts.GetLogger().LogError(tag, content, 2, args);
        }
    }
}
