//------------------------------------------------------------
//        File:  EAPropertiesOp.cs
//       Brief:  EAPropertiesOp
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using System;
using Battle.Common.Constant;
using Battle.Common.Context.Message.Effect;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Extension;
using Battle.Logic.Utils;
using SkillModule.Runtime.Effect;
using vFrame.Lockstep.Core;

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

            var formulaId = effectParams.FormulaData.FormulaId;
            var formulaArgs = effectParams.FormulaData.FormulaArgs;
            var ret = FormulaUtil.Compute(Contexts, 
                formulaId, 
                formulaArgs,
                source,
                target,
                out var newValue);

            if (!ret) {
                return false;
            }

            // 应用公式计算得到的属性值
            ApplyPropOp(target, effectEntity, newValue);
            
            return true;
        }

        private void ApplyPropOp(LogicThingEntity target, LogicEffectEntity effectEntity, FixedPoint newValue) {
            var snapshot1 = target.CollectCombatValue(Contexts);
            var delta = UpdatePropValue(effectEntity, target, newValue);
            var snapshot2 = target.CollectCombatValue(Contexts);
            effectEntity.ReplaceCombatValueDelta(snapshot2 - snapshot1);
            effectEntity.ReplacePropOpDelta(delta);
        }

        private FixedPoint UpdatePropValue(LogicEffectEntity effectEntity, LogicThingEntity target,
            FixedPoint newValue) {
            if (!(Effect.EffectParams is Effect_PropertiesOpData effectParams)) {
                return 0f;
            }

            var propType = (ThingPropertyType) effectParams.TargetPropertyType;
            var sourceValue = target.GetPropValue(propType);
            var oldValue = sourceValue;
            switch (effectParams.TargetPropertyOpType) {
                case EffectTargetPropertyOpType.Add:
                    sourceValue += newValue;
                    break;
                case EffectTargetPropertyOpType.Minus:
                    sourceValue -= newValue;
                    break;
                case EffectTargetPropertyOpType.Multiply:
                    sourceValue *= newValue;
                    break;
                case EffectTargetPropertyOpType.Divide:
                    sourceValue /= newValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unhandled target Prop op type:{effectParams.TargetPropertyOpType}");
            }
            
            // TODO 发送属性操作事件(伤害减免，伤害吸收处理)， 收集属性操作现场数据，记录属性操作

            // 设置对应属性数值
            var realValue = Contexts.SetPropValueEx(target, propType, sourceValue);

            var delta = sourceValue - oldValue;
            return delta;
        }
        
        private void SendPropertyModificationMessage(LogicEffectEntity effectEntity, bool randomHit) {
            if (!effectEntity.hasEffectSource || !effectEntity.hasEffectUserData) {
                return;
            }

            if (!(Effect.EffectParams is Effect_PropertiesOpData effectParams)) {
                return;
            }

            var source = effectEntity.effectSource.Value;
            var userData = effectEntity.effectUserData.Value;
            var delta = effectEntity.propOpDelta.Value;

            var e = RefPool<EffectPropModificationMessage>().Get();
            e.TargetId = effectEntity.effect.TargetId;
            e.PropertyType = effectParams.TargetPropertyType;
            e.DeltaValue = delta;
            e.Source = source;
            e.UserData = userData;
            e.FormulaId = effectParams.FormulaData.FormulaId;
            Contexts.SendMessage(e);
        }
    }
}