//------------------------------------------------------------
//        File:  ViewReactiveSystem.cs
//       Brief:  ViewReactiveSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using System.Collections.Generic;
using Core.Lite.Loggers;
using Entitas;

namespace Battle.View.Base.System
{
    internal abstract class ViewReactiveSystem<TEntity> : ReactiveSystem<TEntity> where TEntity : class, IEntity
    {
        protected readonly ViewContexts Contexts;
        
        protected ViewReactiveSystem(ViewContexts contexts, IContext<TEntity> context) : base(context) {
            Contexts = contexts;
        }
        
        protected abstract override ICollector<TEntity> GetTrigger(IContext<TEntity> context);

        protected abstract override bool Filter(TEntity entity);

        protected abstract override void Execute(List<TEntity> entities);
        
        protected BattleViewConfig ViewConfigs => Contexts.GetController().GetViewConfig();
        
        protected void LogWarning(LogTag tag, string content, params object[] args) {
            Logger.LogWarning(tag, content, args);
        }

        protected void LogError(LogTag tag, string content, params object[] args) {
            Logger.LogError(tag, content, args);
        }
    }
}
