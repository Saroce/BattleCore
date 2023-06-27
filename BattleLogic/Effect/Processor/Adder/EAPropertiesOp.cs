//------------------------------------------------------------
//        File:  EAPropertiesOp.cs
//       Brief:  EAPropertiesOp
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

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
        }
    }
}