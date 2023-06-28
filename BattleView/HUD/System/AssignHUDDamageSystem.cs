//------------------------------------------------------------
//        File:  AssignHUDDamageSystem.cs
//       Brief:  给飘字赋值
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-28
//============================================================

using System.Collections.Generic;
using Battle.View.Base.System;
using Entitas;
using UnityEngine.UI;

namespace Battle.View.HUD.System
{
    internal class AssignHUDDamageSystem : ViewReactiveSystem<ViewHUDEntity>
    {
        public AssignHUDDamageSystem(ViewContexts contexts) : base(contexts, contexts.viewHUD) {
        }

        protected override ICollector<ViewHUDEntity> GetTrigger(IContext<ViewHUDEntity> context) {
            return context.CreateCollector(ViewHUDMatcher.HUDDamageValue);
        }

        protected override bool Filter(ViewHUDEntity entity) {
            return entity.hasHUDView;
        }

        protected override void Execute(List<ViewHUDEntity> entities) {
            foreach (var hudEntity in entities) {
                var view = hudEntity.hUDView.Value;
                var numberText = view.GetComponentInChildren<Text>();
                numberText.text = hudEntity.hUDDamageValue.Value.ToString();
            }
        }
    }
}