//------------------------------------------------------------
//        File:  EAPropertiesOp.cs
//       Brief:  EAPropertiesOp
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using SkillModule.Runtime.Effect;

namespace Battle.Logic.Effect.Processor.Adder
{
    internal class EAPropertiesOp : EffectAdderBase<Effect_PropertiesOpData>
    {
        protected override bool OnProcess(LogicEffectEntity effectEntity, Effect_PropertiesOpData effectParams) {
            // TODO 属性操作处理，需要结合公式来
            
            return false;
        }
    }
}