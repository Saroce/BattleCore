//------------------------------------------------------------
//        File:  AssignHUDHPSystem.cs
//       Brief:  更新血条变化
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using System.Collections.Generic;
using Battle.View.Base.System;
using DG.Tweening;
using Entitas;
using UnityEngine.UI;

namespace Battle.View.HUD.System
{
    internal class AssignHUDHPSystem : ViewReactiveSystem<ViewHUDEntity>
    {
        public AssignHUDHPSystem(ViewContexts contexts) : base(contexts, contexts.viewHUD) {
        }

        protected override ICollector<ViewHUDEntity> GetTrigger(IContext<ViewHUDEntity> context) {
            return context.CreateCollector(ViewHUDMatcher.HUDHP);
        }

        protected override bool Filter(ViewHUDEntity entity) {
            return entity.hasHUDView;
        }

        protected override void Execute(List<ViewHUDEntity> entities) {
            foreach (var hudEntity in entities) {
                var value = (float)hudEntity.hUDHP.Current / hudEntity.hUDHP.Maximum;
                var view = hudEntity.hUDView.Value;
                var slider = view.transform.Find("hp").GetComponent<Image>();
                slider.fillAmount = value;

                var sliderBg = view.transform.Find("midHp").GetComponent<Image>();
                sliderBg.DOKill();
                sliderBg.DOFillAmount(value, 0.4f);
            }
        }
    }
}