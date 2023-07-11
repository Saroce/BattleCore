//------------------------------------------------------------
//        File:  ThingQueryUtil.cs
//       Brief:  ThingQueryUtil
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-11
//============================================================

using System.Collections.Generic;
using Battle.Logic.Constant;
using Battle.Logic.Thing.Extension;
using Core.Lockstep.Math;
using Entitas;
using SkillModule.Runtime.Skill;

namespace Battle.Logic.Utils
{
    public static class ThingQueryUtil
    {
        /// <summary>
        /// 已目标为中心查询一定范围内的生物
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="targetEntity"></param>
        /// <param name="radius"></param>
        /// <param name="targets"></param>
        /// <param name="matcher"></param>
        public static void QueryEntitiesAround(LogicContexts contexts, LogicThingEntity targetEntity,
            FixedPoint radius, ref List<ulong> targets, IMatcher<LogicThingEntity> matcher = null) {
            matcher ??= LogicThingDef.CreatureMatchers;

            var ret = contexts.HashSetPool<ulong>().Get();
            foreach (var entity in contexts.logicThing.GetEntities(matcher)) {
                if (targetEntity.GetDistance(entity) <= radius) {
                    ret.Add(entity.id.Value);
                }
            }
            
            targets.AddRange(ret);
            contexts.HashSetPool<ulong>().Return(ret);
        }
        
        /// <summary>
        /// 查询目标施法范围内的所有生物
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="thingEntity"></param>
        /// <param name="rangeData"></param>
        /// <param name="rangeExData"></param>
        /// <param name="targets"></param>
        /// <param name="matcher"></param>
        public static void QueryEntitiesInRange(LogicContexts contexts, LogicThingEntity thingEntity,
            SkillRangeData rangeData, SkillRangeExData rangeExData, ref List<ulong> targets,
            IMatcher<LogicThingEntity> matcher = null) {
            var oriPosition = thingEntity.position.Value;
            var oriRotation = thingEntity.rotation.Value;

            matcher = matcher ?? LogicThingDef.CreatureMatchers;
            var ret = contexts.HashSetPool<ulong>().Get();

            // TODO 这里有格子范围判定, 看需不需要

            var entities = contexts.logicThing.GetEntities(matcher);
            foreach (var entity in entities) {
                var radius = (FixedPoint) 0f;
                if (entity.hasRadius) {
                    radius = entity.radius.Value;
                }

                if (RangeUtil.IsRangeOverlap(oriPosition, oriRotation, entity.position.Value, radius,
                        rangeData)) {
                    ret.Add(entity.id.Value);
                }
            }

            targets.AddRange(ret);
            contexts.HashSetPool<ulong>().Return(ret);
        }
    }
}