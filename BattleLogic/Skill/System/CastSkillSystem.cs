﻿//------------------------------------------------------------
//        File:  CastSkillSystem.cs
//       Brief:  CastSkillSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-16
//============================================================

using System.Collections.Generic;
using Battle.Common.Context.Combat;
using Battle.Logic.Base.System;
using Battle.Logic.Constant;
using Battle.Logic.Skill.Component.Flux;
using Battle.Logic.Skill.Utils;
using Entitas;
using SkillModule.Runtime.Skill;
using vFrame.Lockstep.Core;

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
            
            var startTime = (FixedPoint) 0f;
            var events = ListPool<SkillFluxEventContext>().Get();
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
            var sequence = DataReader.ReadData<FluxSkillEventData>(sequencePath);
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
                
            }
        }
    }
}