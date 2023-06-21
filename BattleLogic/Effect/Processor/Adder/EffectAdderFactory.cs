//------------------------------------------------------------
//        File:  EffectAdderFactory.cs
//       Brief:  EffectAdderFactory
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using System;
using SkillModule.Runtime.Effect;

namespace Battle.Logic.Effect.Processor.Adder
{
    internal static class EffectAdderFactory
    {
        public static EffectAdderBase CreateProcessor(LogicContexts contexts, EffectData effectData) {
            EffectAdderBase processor;
            switch (effectData.EffectType) {
                case EffectType.PropertiesOp:
                    processor = contexts.RefPool<EAPropertiesOp>().Get();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Create effect processor failed, Unhandled effect type:{effectData.EffectType}");
            }

            processor.Create(contexts);
            processor.Effect = effectData;
            return processor;
        }

        public static void DestroyProcessor(LogicContexts contexts, EffectAdderBase processor) {
            processor.Destroy();

            switch (processor) {
                case EAPropertiesOp propertiesOp:
                    contexts.RefPool<EAPropertiesOp>().Return(propertiesOp);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Destroy effect processor failed, Unhandled type:{processor.GetType().FullName}");
            }
        }
    }
}