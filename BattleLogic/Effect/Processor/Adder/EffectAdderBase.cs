//------------------------------------------------------------
//        File:  EffectAdderBase.cs
//       Brief:  EffectAdderBase
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Constant;
using SkillModule.Runtime.Effect;

namespace Battle.Logic.Effect.Processor.Adder
{
    internal abstract class EffectAdderBase : LogicContextsBridge
    {
        public EffectData Effect { get; set; }

        public abstract void Process(LogicEffectEntity effectEntity);
    }

    internal abstract class EffectAdderBase<T> : EffectAdderBase where T : EffectParams
    {
        public override void Process(LogicEffectEntity effectEntity) {
            if (!(Effect.EffectParams is T effectParams)) {
                LogError(LogTagDef.EffectLogTag, "Effect params is not typeof: {0}", typeof(T).Name);
                return;
            }

            if (!OnProcess(effectEntity, effectParams)) {
                return;
            }

            effectEntity.isEffectApplied = true;
        }

        protected abstract bool OnProcess(LogicEffectEntity effectEntity, T effectParams);
    }
}