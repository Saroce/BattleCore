//------------------------------------------------------------
//        File:  EffectUtil.cs
//       Brief:  EffectUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Effect.Processor.Adder;
using SkillModule.Runtime.Effect;

namespace Battle.Logic.Effect.Utils
{
    internal static class EffectUtil
    {
        public static void ProcessEffectAdder(LogicContexts contexts, LogicEffectEntity effectEntity,
            EffectData effectData) {
            // 创建效果处理器
            var processor = EffectAdderFactory.CreateProcessor(contexts, effectData);
            processor.Process(effectEntity);
            EffectAdderFactory.DestroyProcessor(contexts, processor);
        }
    }
}