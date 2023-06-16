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
using Core.Unity.Behaviours;
using Core.Unity.Extensions;
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
        
        /// <summary>
        /// 创建技能视图的播放
        /// </summary>
        /// <param name="skillEntity"></param>
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

            // 可能是非指向性技能，没有目标
            var targetEntity = Contexts.viewThing.GetEntityWithId(casterContext.TargetId);
            if (targetEntity != null && targetEntity.hasAvatarView) {
                targetTransform = targetEntity.avatarView.ViewObject.transform;
            }
            
            var castSpeed = skillEntity.hasSkillCastSpeedScale ? skillEntity.skillCastSpeedScale.Value.AsFloat() : 1f;
            
            if (CreateAndPlayStartSequence(skillEntity, casterTransform, targetTransform, castSpeed)) {
                return;
            }

            if (CreateAndPlayContinuousSequence(skillEntity, casterTransform, targetTransform, castSpeed)) {
                return;
            }
            
            LogError(LogTagDef.SkillLogTag, "No valid skill view created, caster id: {0}, skill guid: {1}",
                skillEntity.skillCastContext.OwnerId, skillEntity.skillCastContext.Ability.Guid);
        }

        /// <summary>
        /// 起手技能序列
        /// </summary>
        /// <param name="skillEntity"></param>
        /// <param name="casterTransform"></param>
        /// <param name="targetTransform"></param>
        /// <param name="castSpeed"></param>
        /// <returns></returns>
        private bool CreateAndPlayStartSequence(ViewSkillEntity skillEntity, Transform casterTransform,
            Transform targetTransform, float castSpeed) {
            if (!skillEntity.hasSkillSequence) {
                return false;
            }

            var seq = CreateSequenceAndPlay(skillEntity.skillSequence.Path, 
                skillEntity,
                casterTransform,
                targetTransform, 
                castSpeed,
                () => {
                    // TODO 快照还原
                    skillEntity.RecycleSequence();
                    CreateAndPlayContinuousSequence(skillEntity, casterTransform, targetTransform, castSpeed);
                });

            return seq != null;
        }

        /// <summary>
        /// 持续技能序列
        /// </summary>
        /// <param name="skillEntity"></param>
        /// <param name="casterTransform"></param>
        /// <param name="targetTransform"></param>
        /// <param name="castSpeed"></param>
        /// <returns></returns>
        private bool CreateAndPlayContinuousSequence(ViewSkillEntity skillEntity, Transform casterTransform,
            Transform targetTransform, float castSpeed) {
            if (!skillEntity.hasSkillContinuousSequence) {
                return false;
            }
            
            var seq = CreateSequenceAndPlay(skillEntity.skillContinuousSequence.Path, 
                skillEntity,
                casterTransform,
                targetTransform, 
                castSpeed);
            
            // 根据配置将技能序列设置为循环
            if (seq != null && skillEntity.skillContinuousSequence.Loop) {
                seq.Loop = true;
            }

            // 持续配置时间后，回收持续序列，尝试创建收尾技能序列
            var duration = skillEntity.skillContinuousSequence.Duration;
            seq.gameObject.GetOrAddComponent<MethodInvoker>().DelayInvoke(duration, (contexts, entity) => {
                // TODO 快照处理
                entity.RecycleSequence();
                CreateAndPlayEndSequence(skillEntity, casterTransform, targetTransform, castSpeed);
            }, 
            Contexts,
            skillEntity);

            return seq != null;
        }

        /// <summary>
        /// 收尾技能序列
        /// </summary>
        /// <param name="skillEntity"></param>
        /// <param name="casterTransform"></param>
        /// <param name="targetTransform"></param>
        /// <param name="castSpeed"></param>
        /// <returns></returns>
        private bool CreateAndPlayEndSequence(ViewSkillEntity skillEntity, Transform casterTransform,
            Transform targetTransform, float castSpeed) {
            if (!skillEntity.hasSkillEndingSequence) {
                return false;
            }
            
            var seq = CreateSequenceAndPlay(skillEntity.skillEndingSequence.Path, 
                skillEntity,
                casterTransform,
                targetTransform, 
                castSpeed, 
                () => {
                    // TODO 快照处理
                    skillEntity.RecycleSequence();
                });

            return seq != null;
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
            skillEntity.AddSkillView(go);
            seq.RuntimeArgs = new FRuntimeArgs() {
                Caster = casterTransform,
                Target = targetTransform
            };
            seq.RuntimeSetting = Contexts.GetFluxRuntimeSetting();
            // TODO 序列速度控制
            seq.ReplaceOwner(casterTransform);
            
            seq.gameObject.Link(skillEntity);
            seq.OnFinishedCallback.RemoveAllListeners();
            seq.OnFinishedCallback.AddListener(v => {
                onFinish?.Invoke();
            });
            seq.Play();

            LogDebug(LogTagDef.SkillLogTag, "Skill view sequence created, casterId: {0}, path: {1}",
                skillEntity.skillCasterId.Id, sequencePath);
            
            return seq;
        }
    }
}