//------------------------------------------------------------
//        File:  OnSkillJudgeHit.cs
//       Brief:  OnSkillJudgeHit
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Common.Context.Message.Skill;

namespace Battle.View.Input.System.Processor
{
    internal class OnSkillJudgeHit : MessageProcessor<SkillJudgeHitMessage>
    {
        /// <summary>
        /// 技能判定命中效果处理
        /// </summary>
        /// <param name="message"></param>
        protected override void OnProcess(SkillJudgeHitMessage message) {
            foreach (var target in message.Targets) {
                if (string.IsNullOrEmpty(message.EffectData.HitSequencePath)) {
                    return;
                }
                
                CreateSkillHitEffect(message, target);
                // TODO 受击效果表现
            }
        }

        private void CreateSkillHitEffect(SkillJudgeHitMessage message, ulong targetId) {
            var skillEntity = Contexts.viewSkill.CreateEntity();
            skillEntity.AddSkillHitContext(targetId);
            skillEntity.AddSkillSequence(message.EffectData.HitSequencePath);
        }
    }
}