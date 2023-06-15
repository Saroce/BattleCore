//------------------------------------------------------------
//        File:  AddSkillCastViewSystem.cs
//       Brief:  AddSkillCastViewSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-15
//============================================================

using System;
using System.Collections.Generic;
using Battle.View.Base;
using Battle.View.Base.System;
using Battle.View.Constant;
using DG.Tweening;
using Entitas;
using Entitas.Unity;
using Flux;
using Flux.Runtime;
using SkillModule.Runtime.Skill;
using UnityEngine;

namespace Battle.View.Skill.System
{
    internal class AddSkillCastViewSystem : ViewReactiveSystem<ViewSkillEntity>
    {
        public AddSkillCastViewSystem(ViewContexts contexts) : base(contexts, contexts.viewSkill) {
        }

        protected override ICollector<ViewSkillEntity> GetTrigger(IContext<ViewSkillEntity> context) {
            return context.CreateCollector(ViewSkillMatcher.SkillCastContext);
        }

        protected override bool Filter(ViewSkillEntity entity) {
            return entity.hasSkillCastContext &&
                   entity.hasSkillCasterId &&
                   (entity.hasSkillSequence || entity.hasSkillContinuousSequence);
        }

        protected override void Execute(List<ViewSkillEntity> entities) {
            foreach (var entity in entities) {
                RotateCaster(entity);
                CreateSkillView(entity);
            }
        }

        /// <summary>
        /// 指向性技能需要转向玩家
        /// </summary>
        /// <param name="skillEntity"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void RotateCaster(ViewSkillEntity skillEntity) {
            var casterEntity = Contexts.viewThing.GetEntityWithId(skillEntity.skillCastContext.OwnerId);
            if (casterEntity == null || !casterEntity.hasAvatarView) {
                return;
            }

            var skillData = skillEntity.skillCastContext.Ability.ActiveSkillData;
            if (skillData == null) {
                return;
            }

            // 非指向性技能不转向
            if (!skillData.BaseData.IsDirectional) {
                return;
            }

            switch (skillData.BaseData.DirectionalType) {
                case SkillDirectionalType.ToThing: {
                    var targetEntity = Contexts.viewThing.GetEntityWithId(skillEntity.skillCastContext.TargetId);
                    if (targetEntity == null || !targetEntity.hasAvatarView) {
                        return;
                    }
                    
                    RotateToLockTarget(casterEntity, targetEntity);
                    break;
                }
                case SkillDirectionalType.ToGround:
                    RotateToLockGround(casterEntity);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unhandled direction type:{skillData.BaseData.DirectionalType}");
            }
        }

        private void RotateToLockGround(ViewThingEntity casterEntity) {
            if (!casterEntity.hasRotation) {
                return;
            }
            
            if (casterEntity.hasAvatarRotateTween) {
                DOTween.Kill(casterEntity.avatarRotateTween.TweenId);
                casterEntity.RemoveAvatarRotateTween();
            }
            
            // TODO 这里暂时强制设置施法者转向为对应物体逻辑实体的旋转方向
            casterEntity.avatarView.ViewObject.transform.localRotation = casterEntity.rotation.Value.ToUnityQuaternion();
        }

        private void RotateToLockTarget(ViewThingEntity casterEntity, ViewThingEntity targetEntity) {
            if (casterEntity.hasAvatarRotateTween) {
                DOTween.Kill(casterEntity.avatarRotateTween.TweenId);
                casterEntity.RemoveAvatarRotateTween();
            }

            var casterPosition = casterEntity.avatarView.Container.transform.position;
            var targetPosition = targetEntity.avatarView.Container.transform.position;
            var direction = targetPosition - casterPosition;
            direction.y = 0;
            
            if (direction == Vector3.zero) {
                return;
            }

            // 强制将施法者转向目标
            var rotation = Quaternion.LookRotation(direction);
            casterEntity.avatarView.ViewObject.transform.localRotation = rotation;
        }
        
        private void CreateSkillView(ViewSkillEntity skillEntity) {
            var casterTransform = (Transform)null;
            var targetTransform = (Transform)null;

            var casterContext = skillEntity.skillCastContext;
            var casterEntity = Contexts.viewThing.GetEntityWithId(casterContext.OwnerId);
            if (casterEntity == null || !casterEntity.hasAvatarView) {
                LogWarning(LogTagDef.SkillLogTag, "In create skill view try get caster entity failed, id: {0}", casterContext.OwnerId);
                return;
            }
            casterTransform = casterEntity.avatarView.ViewObject.transform;

            var targetEntity = Contexts.viewThing.GetEntityWithId(casterContext.TargetId);
            if (targetEntity == null || !targetEntity.hasAvatarView) {
                LogWarning(LogTagDef.SkillLogTag, "In create skill view try get target entity failed, id: {0}", casterContext.TargetId);
                return;
            }
            targetTransform = targetEntity.avatarView.ViewObject.transform;

            var castSpeed = skillEntity.hasSkillCastSpeedScale ? skillEntity.skillCastSpeedScale.Value : 1f;
        }

        private bool CreateAndPlayStartSequence(ViewSkillEntity skillEntity, Transform casterTransform,
            Transform targetTransform, float castSpeed) {
            if (!skillEntity.hasSkillSequence) {
                return false;
            }

            var sequence = CreateSequenceAndPlay(skillEntity.skillSequence.Path, 
                skillEntity,
                casterTransform,
                targetTransform, 
                castSpeed,
                () => {
                    // TODO 
                });

            return sequence != null;
        }

        private FSequence CreateSequenceAndPlay(string sequencePath, 
            ViewSkillEntity skillEntity,
            Transform casterTransform,
            Transform targetTransform, 
            float castSpeed,
            Action onFinish = null) {

            if (string.IsNullOrEmpty(sequencePath)) {
                return null;
            }

            var root = GameObjectRoots.GetRoot(ViewConst.SkillsRootName);
            var pool = Contexts.GetBattleContext().SpawnPool;
            var go = pool[sequencePath].Spawn();
            if (go == null) {
                LogError(LogTagDef.SkillLogTag, "Spawn sequence go failed path: {0}", sequencePath);
                return null;
            }
            
            go.transform.SetParent(root.transform, false);
            var seq = go.GetComponent<FSequence>();
            if (seq == null) {
                LogError(LogTagDef.SkillLogTag, "Skill view has no sequence: {0}", sequencePath);
                pool[sequencePath].Recycle(go);
                return null;
            }
            
            // TODO 快照处理
            seq.RuntimeArgs = new FRuntimeArgs() {
                Caster = casterTransform,
                Target = targetTransform
            };
            // TODO  Sequence RuntimeSetting
            seq.ReplaceOwner(casterTransform);

            seq.gameObject.Link(skillEntity);
            
        }
    }
}