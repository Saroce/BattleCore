//------------------------------------------------------------
//        File:  AddEffectSystem.cs
//       Brief:  AddEffectSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using System.Collections.Generic;
using Battle.Logic.Base.System;
using Battle.Logic.Effect.Utils;
using Entitas;

namespace Battle.Logic.Effect.System
{
    internal class AddEffectSystem : LogicReactiveSystem<LogicEffectEntity>
    {
        private static readonly IMatcher<LogicEffectEntity> EffectMatcher = LogicEffectMatcher.ToAdd;

        public AddEffectSystem(LogicContexts contexts) : base(contexts, contexts.logicEffect) {
        }

        protected override ICollector<LogicEffectEntity> GetTrigger(IContext<LogicEffectEntity> context) {
            return context.CreateCollector(EffectMatcher);
        }

        protected override bool Filter(LogicEffectEntity entity) {
            return entity.hasEffect;
        }

        protected override void Execute(List<LogicEffectEntity> entities) {
            foreach (var effectEntity in entities) {
                var effectData = effectEntity.effect.EffectData;
                EffectUtil.ProcessEffectAdder(Contexts, effectEntity, effectData);

                if (effectEntity.isDestroyAfterProcess) {
                    effectEntity.isDestroyed = true;
                }

                effectEntity.isToAdd = false;
            }
        }
    }
}