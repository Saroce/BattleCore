﻿//------------------------------------------------------------
//        File:  EAPropertiesOp.cs
//       Brief:  EAPropertiesOp
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Constant;
using SkillModule.Runtime.Effect;

namespace Battle.Logic.Effect.Processor.Adder
{
    internal class EAPropertiesOp : EffectAdderBase<Effect_PropertiesOpData>
    {
        protected override bool OnProcess(LogicEffectEntity effectEntity, Effect_PropertiesOpData effectParams) {
            var sourceId = effectEntity.effect.SourceId;
            var targetId = effectEntity.effect.TargetId;

            var source = Contexts.logicThing.GetEntityWithId(sourceId);
            if (source == null) {
                LogWarning(LogTagDef.EffectLogTag, "Effect source entity not found: {0}", sourceId);
                return false;
            }
            
            var target = Contexts.logicThing.GetEntityWithId(targetId);
            if (target == null) {
                return false;
            }
            
            
            
            return false;
        }
    }
}