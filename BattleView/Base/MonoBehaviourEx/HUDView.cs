//------------------------------------------------------------
//        File:  HUDView.cs
//       Brief:  HUDView
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-20
//============================================================

using System;
using Core.Unity.Extensions;
using Entitas.Unity;
using UnityEngine;

namespace Battle.View.Base.MonoBehaviourEx
{
    public class HUDView : BattleViewBehaviour
    {
        private ViewHUDEntity _entity;
        private Animation _animation;
        private bool _isDestroyWhenPlayFinished;

        private void Awake() {
            _animation = GetComponent<Animation>();
            _isDestroyWhenPlayFinished = false;
        }

        public void Link(ViewHUDEntity entity) {
            _entity = entity;
            gameObject.Link(entity);
        }

        public void PlayAnimation(bool autoDestroy) {
            if (!_animation) {
                return;
            }

            _animation.Reset();
            _animation.Play();

            _isDestroyWhenPlayFinished = autoDestroy;
            enabled = true;
        }
        
        public void PlayAnimation(string aniName, bool autoDestroy) {
            if (!_animation) {
                return;
            }
            
            _animation.Reset();
            _animation.Play(aniName);

            _isDestroyWhenPlayFinished = autoDestroy;
        }

        private void Update() {
            if (!_isDestroyWhenPlayFinished) {
                return;
            }
            if (_animation.isPlaying) {
                return;
            }

            _entity.isDestroyed = true;
        }

        public void Stop() {
            enabled = false;
        }
    }
}