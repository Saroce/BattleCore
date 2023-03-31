//------------------------------------------------------------
//        File:  LogicReactiveSystem.cs
//       Brief:  LogicReactiveSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using System.Collections.Generic;
using Entitas;

namespace Battle.Logic.Base.System
{
    internal abstract class LogicReactiveSystem<TEntity> : ReactiveSystem<TEntity> where TEntity : class, IEntity
    {
        protected LogicContexts Contexts { get; }
        
        public LogicReactiveSystem(LogicContexts contexts, IContext<TEntity> context) : base(context) {
            Contexts = contexts;
        }

        protected abstract override ICollector<TEntity> GetTrigger(IContext<TEntity> context);

        protected abstract override bool Filter(TEntity entity);

        protected abstract override void Execute(List<TEntity> entities);
    }
}
