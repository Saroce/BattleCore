//------------------------------------------------------------
//        File:  SkillEx.cs
//       Brief:  SkillEx
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-16
//============================================================

using Core.Unity.Behaviours;
using Entitas.Unity;
using Flux;
using UnityEngine;

namespace Battle.View.Skill
{
    public static class SkillEx
    {
        public static void RecycleSequence(this ViewSkillEntity skillEntity) {
            if (!skillEntity.hasSkillView) {
                return;
            }

            var view = skillEntity.skillView.Value;
            view.Unlink();

            var invoker = view.GetComponent<MethodInvoker>();
            if (invoker) {
                invoker.Stop();
            }

            var seq = view.GetComponent<FSequence>();
            if (seq != null) {
                seq.Stop(true);
                seq.OnFinishedCallback.RemoveAllListeners();
                seq.OnCustomCallbackEvent.RemoveAllListeners();
                seq.RuntimeArgs = null;
                seq.RuntimeSetting = null;
            }
            
            // TODO 暂时先不回收技能序列
            Object.Destroy(view);
            skillEntity.RemoveSkillView();
        }
    }
}