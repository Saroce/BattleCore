//------------------------------------------------------------
//        File:  ThingExtension.cs
//       Brief:  ThingExtension
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-31
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Logic.Utils;
using Core.Lite.RefPool.Builtin;
using Core.Lockstep.Math;

namespace Battle.Logic.Thing.Extension
{
    internal static class ThingEx
    {
        public static ThingType GetThingType(this LogicThingEntity thingEntity) {
            if (thingEntity.isGamer) {
                return ThingType.Gamer;
            }

            if (thingEntity.isMonster) {
                return ThingType.Monster;
            }

            if (thingEntity.isBullet) {
                return ThingType.Bullet;
            }
            
            return ThingType.Unknown;
        }
        
        /// <summary>
        /// 计算两个物件间的距离
        /// </summary>
        /// <param name="thingA"></param>
        /// <param name="thingB"></param>
        /// <returns></returns>
        public static FixedPoint GetDistance(this LogicThingEntity thingA, LogicThingEntity thingB) {
            if (!thingA.hasPosition || !thingB.hasPosition) {
                return FixedPoint.MaxValue;
            }

            var radiusA = thingA.hasRadius ? thingA.radius.Value : 0;
            var radiusB = thingB.hasRadius ? thingB.radius.Value : 0;

            var positionA = thingA.position.Value;
            var positionB = thingB.position.Value;

            return (positionA - positionB).magnitude - radiusA - radiusB;
        }

        public static FixedPoint GetCastSpeedScale(this LogicThingEntity thingEntity, LogicContexts contexts,
            SkillConfData ability) {
            // TODO 暂时默认返回1
            return ThingCastSpeed.Default;
        }
        
        public static string GetThingSummary(this LogicThingEntity thingEntity) {
            var builder = StringBuilderPool.Shared.Get();
            builder.Append("[ThingType: ");
            builder.Append(thingEntity.GetThingType());

            if (thingEntity.hasId) {
                builder.Append(", Id: ");
                builder.Append(thingEntity.id.Value);
            }

            builder.Append("]");
            return builder.ToString();
        }

        public static void ReadAbilities(this LogicContexts contexts, LogicThingEntity thingEntity, int defSkillId,
            int ultSkillId, params int[] allSkills) {

            SkillLevelData defSkill = null;
            if (defSkillId > 0) {
                defSkill = new SkillLevelData(defSkillId);
            }

            SkillLevelData ultSkill = null;
            if (ultSkillId > 0) {
                ultSkill = new SkillLevelData(ultSkillId);
            }

            var skillsData = contexts.ListPool<SkillLevelData>().Get();
            foreach (var skill in allSkills) {
                if (skill > 0) {
                    skillsData.Add(skill);
                }
            }

            contexts.ReadAbilities(thingEntity, defSkill, ultSkill, skillsData.ToArray());
            contexts.ListPool<SkillLevelData>().Return(skillsData);
        }

        private static void ReadAbilities(this LogicContexts contexts, LogicThingEntity thingEntity,
            SkillLevelData defSkillData, SkillLevelData ultSkillData, params SkillLevelData[] allSkillsData) {
            
            SkillConfData defaultSkill = null;
            if (null != defSkillData) {
                defaultSkill = ConfigUtil.ReadSkillConfData(contexts, defSkillData.Id, defSkillData.Level);
            }
            SkillConfData ultimateSkill = null;
            if (null != ultSkillData) {
                ultimateSkill = ConfigUtil.ReadSkillConfData(contexts, ultSkillData.Id, ultSkillData.Level);
            }

            SkillConfData[] skills = null;
            if (null != allSkillsData) {
                var skillList = contexts.ListPool<SkillConfData>().Get();
                foreach (var skillData in allSkillsData) {
                    if (null == skillData) {
                        continue;
                    }
                    var confData = ConfigUtil.ReadSkillConfData(contexts, skillData.Id, skillData.Level);
                    skillList.Add(confData);
                }
                skills = skillList.ToArray();
                contexts.ListPool<SkillConfData>().Return(skillList);
            }
            
            contexts.ReadSkillAbilities(thingEntity, defaultSkill, ultimateSkill, skills);
        }
    }
}