//------------------------------------------------------------
//        File:  CastSkillSystem.cs
//       Brief:  CastSkillSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-16
//============================================================

using System;
using System.Collections.Generic;
using Battle.Common.Constant;
using Battle.Common.Context.Combat;
using Battle.Logic.Base.System;
using Battle.Logic.Constant;
using Battle.Logic.Skill.Component.Flux;
using Battle.Logic.Skill.Utils;
using Core.Lockstep.Math;
using Entitas;
using SkillModule.Runtime.Skill;

namespace Battle.Logic.Skill.System
{
    internal class CastSkillSystem : LogicReactiveSystem<LogicSkillEntity>
    {
        private static readonly IMatcher<LogicSkillEntity> SkillMatcher = LogicSkillMatcher.SkillCastContext;

        public CastSkillSystem(LogicContexts contexts) : base(contexts, contexts.logicSkill) {
        }

        protected override ICollector<LogicSkillEntity> GetTrigger(IContext<LogicSkillEntity> context) {
            return context.CreateCollector(SkillMatcher);
        }

        protected override bool Filter(LogicSkillEntity entity) {
            return entity.hasSkillCastContext && entity.hasId;
        }

        protected override void Execute(List<LogicSkillEntity> entities) {
            foreach (var skillEntity in entities) {
                var skillContext = skillEntity.skillCastContext;
                LogDebug(LogTagDef.SkillLogTag, "Skill context added, caster id: {0}, skill guid: {1}, target id: {2}",
                    skillContext.CasterId, skillContext.Ability.Guid, skillContext.TargetId);

                ReadAndProcessSkillSequence(skillEntity);
            }
        }

        private void ReadAndProcessSkillSequence(LogicSkillEntity skillEntity) {
            var skillContext = skillEntity.skillCastContext;
            var skillConfData = skillContext.Ability;

            // 持续性技能
            if (skillConfData.ActiveSkillData.BaseData.IsContinuous) {
                // 配置的持续时间 <= 0
                if (skillConfData.ActiveSkillData.BaseData.Duration <= 0) {
                    LogError(LogTagDef.SkillLogTag,
                        "Skill mark as continuous, but duration is less or equal than 0, guid: {0}",
                        skillConfData.Guid);
                    return;
                }

                // 没有配置持续技能序列
                if (string.IsNullOrEmpty(skillConfData.ActiveSkillData.ContinuousTimelineData?.SequencePath)) {
                    LogError(LogTagDef.SkillLogTag,
                        "Skill mark as continuous, but no continuous sequence specified, guid: {0}",
                        skillConfData.Guid);
                    return;
                }
            }

            var startTime = (FixedPoint)0f;
            var events = ListPool<SkillFluxEventContext>().Get();

            // 起手阶段
            if (!ReadFluxEventData(skillConfData.ActiveSkillData.StartTimelineData, skillEntity, startTime, ref events,
                    out var startDuration)) {
                ListPool<SkillFluxEventContext>().Return(events);
                return;
            }

            startTime += startDuration;

            // 持续阶段
            var continuousDuration = (FixedPoint)0f;
            if (skillConfData.ActiveSkillData.BaseData.IsContinuous) {
                if (skillConfData.ActiveSkillData.BaseData.Duration == int.MaxValue) {
                    throw new NotSupportedException("Active skill duration == int.MaxValue is not supported, guid: " +
                                                    skillConfData.ActiveSkillData.Guid);
                }

                continuousDuration = (FixedPoint)skillConfData.ActiveSkillData.BaseData.Duration / 1000f;
                var duration = (FixedPoint)0f;
                while (duration < continuousDuration) {
                    if (!ReadFluxEventData(skillConfData.ActiveSkillData.ContinuousTimelineData, skillEntity, startTime,
                            ref events, out var length)) {
                        break;
                    }

                    duration += length;
                }
            }

            startTime += continuousDuration;

            // 收尾阶段
            var endDuration = (FixedPoint) 0f;
            if (skillConfData.ActiveSkillData.BaseData.IsContinuous) {
                ReadFluxEventData(skillConfData.ActiveSkillData.EndTimelineData, skillEntity, startTime, ref events,
                    out endDuration);
            }
            
            // 按照技能序列触发时间进行排序
            events.Sort((a, b) => a.Time.CompareTo(b.Time));
            
            skillEntity.AddSkillFluxEvents(events);
            skillEntity.AddSkillCastTime(Contexts.GetClock().GetTime());

            var totalDuration = startDuration + continuousDuration + endDuration;
            skillEntity.AddSkillCastDuration(skillContext.CastSpeed * totalDuration);
            
            LogDebug(LogTagDef.SkillLogTag, "Skill sequences read finished, caster id: {0}, skill guid: {1}, total duration: {2}",
                skillContext.CasterId, skillContext.Ability.ActiveSkillData.Guid, totalDuration);
        }

        private bool ReadFluxEventData(ActiveSkillTimelineData timelineData,
            LogicSkillEntity skillEntity,
            FixedPoint startTime,
            ref List<SkillFluxEventContext> events,
            out FixedPoint length) {
            if (timelineData == null) {
                length = 0f;
                return false;
            }

            var sequencePath = timelineData.SequencePath;
            if (string.IsNullOrEmpty(sequencePath)) {
                length = 0f;
                return false;
            }

            // 转换到Flux导出数据文件路径，反序列化得到Flux序列数据
            var seqDataPath = SkillUtil.ConvertToSequenceDataPath(sequencePath);
            var sequence = DataReader.ReadData<FluxSkillEventData>(seqDataPath);
            if (sequence == null) {
                LogError(LogTagDef.SkillLogTag, $"Read sequence failed path: {seqDataPath}");
                length = 0f;
                return false;
            }

            // 得出整个序列文件长度
            length = (FixedPoint)sequence.Length / sequence.FrameRate;
            if (length <= 0f) {
                LogError(LogTagDef.SkillLogTag, "Sequence length <= 0: {0}", sequencePath);
                return false;
            }

            var castContext = skillEntity.skillCastContext;
            var skillConfData = castContext.Ability;

            // 处理Flux的Judge事件
            var judgeList = timelineData.Judges;
            for (var i = 0; i < sequence.Judges.Count; i++) {
                var judgeData = sequence.Judges[i];
                var evt = new JudgeFluxEventContext() {
                    SkillEntityId = skillEntity.id.Value,
                    SkillConfData = skillConfData,
                    JudgeData = judgeList[i],
                    Time = castContext.CastSpeed * (startTime + (FixedPoint)judgeData.StartFrame / sequence.FrameRate),
                    Type = SkillFluxEventType.Judge
                };
                events.Add(evt);
            }

            // 处理Flux的Shoot事件
            var shootList = timelineData.Shoots;
            for (var i = 0; i < sequence.Shoots.Count; i++) {
                var shootData = sequence.Shoots[i];
                var evt = new ShootFluxEventContext() {
                    SkillEntityId = skillEntity.id.Value,
                    SkillConfData = skillConfData,
                    Time = castContext.CastSpeed * (startTime + (FixedPoint)shootData.StartFrame / sequence.FrameRate),
                    Type = SkillFluxEventType.Shoot,
                    ShootData = shootList[i],
                    FluxShootData = shootData
                };
                events.Add(evt);
            }

            return true;
        }
    }
}