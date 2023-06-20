//------------------------------------------------------------
//        File:  SkillJudgeUtil.cs
//       Brief:  SkillJudgeUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-20
//============================================================

using System;
using System.Collections.Generic;
using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Logic.Constant;
using Battle.Logic.Effect;
using Battle.Logic.Skill.Component.Flux;
using SkillModule.Runtime.Skill;
using vFrame.Lockstep.Core;

namespace Battle.Logic.Skill.Utils
{
    internal static class SkillJudgeUtil
    {
        public static void ProcessJudge(LogicContexts contexts, ulong casterId, ulong targetId,
            JudgeFluxEventContext fluxEventContext) {
            var caster = contexts.logicThing.GetEntityWithId(casterId);
            if (null == caster) {
                contexts.LogWarning(LogTagDef.SkillLogTag, "Process judge event, but caster not found: {0}", casterId);
                return;
            }

            contexts.LogDebug(LogTagDef.SkillLogTag,
                "Process judge event, casterId: {0}, skill guid: {1}, judgeId: {2}",
                casterId, fluxEventContext.SkillConfData.Guid, fluxEventContext.JudgeData.Guid);

            // 处理技能判定效果
            foreach (var effectData in fluxEventContext.JudgeData.EffectDataList) {
                var hitTargets = new List<ulong>();
                var userData =
                    BuildEffectUserData(contexts, fluxEventContext, casterId, fluxEventContext.SkillEntityId);

                switch (effectData.JudgeType) {
                    case SkillJudgeType.None:
                        contexts.AddEffect(casterId, 0ul, effectData.EffectData, true, EffectSource.Skill,
                            userData);
                        break;
                    case SkillJudgeType.Single:
                        if (targetId > 0 && SkillTargetSelectUtil.TestRandom(contexts, effectData.Probability)) {
                            contexts.AddEffect(casterId, targetId, effectData.EffectData, true, EffectSource.Skill,
                                userData);
                        }
                        break;
                    case SkillJudgeType.All:
                        break;
                    case SkillJudgeType.Range:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private static EffectUserData BuildEffectUserData(LogicContexts contexts,
            SkillFluxEventContext fluxEventContext, ulong casterId, ulong skillEntityId) {
            var skillData = fluxEventContext.SkillConfData.ActiveSkillData;
            var userData = new EffectUserData() {
                SkillConfData = fluxEventContext.SkillConfData,
                SkillCasterId = casterId,
                SkillEntityId = skillEntityId,
                Duration = (FixedPoint) skillData.BaseData.Duration / 1000f
            };

            return userData;
        }
    }
}