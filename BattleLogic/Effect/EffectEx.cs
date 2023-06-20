//------------------------------------------------------------
//        File:  EffectEx.cs
//       Brief:  EffectEx
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using SkillModule.Runtime.Effect;

namespace Battle.Logic.Effect
{
    public static class EffectEx
    {
        /// <summary>
        /// 对单个目标添加效果
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="sourceId"></param>
        /// <param name="targetId"></param>
        /// <param name="effectData"></param>
        /// <param name="destroyAfterProcessed"></param>
        /// <param name="effectSource"></param>
        /// <param name="userData"></param>
        /// <returns></returns>
        public static ulong AddEffect(this LogicContexts contexts, 
            ulong sourceId, 
            ulong targetId,
            EffectData effectData, 
            bool destroyAfterProcessed,
            EffectSource effectSource,
            EffectUserData userData = new EffectUserData()) {

            var effectEntity = contexts.logicEffect.CreateEntity();
            effectEntity.AddId(contexts.GetIndependentId());
            effectEntity.AddEffect(effectData, sourceId, targetId);
            effectEntity.AddEffectSource(effectSource);
            effectEntity.AddEffectUserData(userData);
            effectEntity.isToAdd = true;
            effectEntity.isDestroyAfterProcess = destroyAfterProcessed;

            return effectEntity.id.Value;
        }
    }
}