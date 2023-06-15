//------------------------------------------------------------
//        File:  OnEnterCast.cs
//       Brief:  OnEnterCast
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using Battle.Common.Context.Message.Thing;

namespace Battle.View.Input.System.Processor
{
    internal class OnEnterCast : MessageProcessor<ThingEnterCastMessage>
    {
        protected override void OnProcess(ThingEnterCastMessage message) {
            CreateCastView(message);
        }

        private void CreateCastView(ThingEnterCastMessage message) {
            var ability = message.Ability;
            if (ability.IsPassive) {
                return;
            }

            // 移除已经存在同一个施法者
            var existSkillEntity = Contexts.viewSkill.GetEntityWithSkillCasterId(message.Id);
            if (existSkillEntity != null) {
                existSkillEntity.isDestroyed = true;
            }

            var skillEntity = Contexts.viewSkill.CreateEntity();
            skillEntity.AddSkillCastContext(message.Id, message.TargetId, ability);
            skillEntity.AddSkillCastSpeedScale(message.CastSpeed);
            skillEntity.AddSkillCasterId(message.Id);

            var skillData = ability.ActiveSkillData;
            if (!string.IsNullOrEmpty(skillData.StartTimelineData.SequencePath)) {
                skillEntity.AddSkillSequence(skillData.StartTimelineData.SequencePath);
            }

            if (!string.IsNullOrEmpty(skillData.ContinuousTimelineData.SequencePath)) {
                skillEntity.AddSkillContinuousSequence(skillData.ContinuousTimelineData.SequencePath,
                    skillData.BaseData.Duration / 1000f, skillData.LoopContinuousSequence);
            }

            if (!string.IsNullOrEmpty(skillData.EndTimelineData.SequencePath)) {
                skillEntity.AddSkillEndingSequence(skillData.EndTimelineData.SequencePath);   
            }
        }
    }
}