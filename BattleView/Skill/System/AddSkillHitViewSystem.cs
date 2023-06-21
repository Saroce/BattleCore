//------------------------------------------------------------
//        File:  AddSkillHitViewSystem.cs
//       Brief:  AddSkillHitViewSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using System.Collections.Generic;
using Battle.View.Base;
using Battle.View.Base.System;
using Battle.View.Constant;
using Entitas;
using Entitas.Unity;
using Flux;
using Flux.Runtime;

namespace Battle.View.Skill.System
{
    internal class AddSkillHitViewSystem : ViewReactiveSystem<ViewSkillEntity>
    {
        public AddSkillHitViewSystem(ViewContexts contexts) : base(contexts, contexts.viewSkill) {
        }

        protected override ICollector<ViewSkillEntity> GetTrigger(IContext<ViewSkillEntity> context) {
            return context.CreateCollector(ViewSkillMatcher.SkillHitContext);
        }

        protected override bool Filter(ViewSkillEntity entity) {
            return entity.hasSkillSequence;
        }

        protected override void Execute(List<ViewSkillEntity> entities) {
            var root = GameObjectRoots.GetRoot(ViewConst.SkillsRootName);
            var pools = Contexts.GetBattleContext().SpawnPool;

            foreach (var skillEntity in entities) {
                var target = Contexts.viewThing.GetEntityWithId(skillEntity.skillHitContext.TargetId);
                if (target == null || !target.hasAvatarView) {
                    continue;
                }

                var hitSeqPath = skillEntity.skillSequence.Path;
                if (string.IsNullOrEmpty(hitSeqPath)) {
                    continue;
                }

                var go = pools[hitSeqPath].Spawn();
                var seq = go.GetComponent<FSequence>();
                if (seq == null) {
                    LogError(LogTagDef.SkillLogTag, "Hit view has no sequence: {0}", hitSeqPath);
                    pools[hitSeqPath].Recycle(go);
                    continue;
                }

                // 获取命中序列后开始播放
                seq.RuntimeSetting = Contexts.GetFluxRuntimeSetting();
                seq.RuntimeArgs = new FRuntimeArgs();
                seq.ReplaceOwner(target.avatarView.ViewObject.transform);
                seq.OnFinishedCallback.RemoveAllListeners();
                seq.OnFinishedCallback.AddListener(v => {
                    skillEntity.isDestroyed = true;
                });
                seq.Play();
                
                go.transform.SetParent(root.transform, false);
                go.Link(skillEntity);
                
                skillEntity.AddSkillView(go);
            }
        }
    }
}