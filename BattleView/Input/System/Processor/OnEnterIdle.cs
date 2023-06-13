//------------------------------------------------------------
//        File:  OnEnterIdle.cs
//       Brief:  OnEnterIdle
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-13
//============================================================

using Battle.Common.Constant;
using Battle.Common.Context.Message.Thing;
using Battle.View.Constant;

namespace Battle.View.Input.System.Processor
{
    internal class OnEnterIdle : MessageProcessor<ThingEnterIdleMessage>
    {
        protected override void OnProcess(ThingEnterIdleMessage message) {
            var entity = Contexts.viewThing.GetEntityWithId(message.Id);
            if (null == entity) {
                return;
            }

            // 消息附带Idle状态动画名称
            if (!string.IsNullOrEmpty(message.MotionName)) {
                entity.ReplaceAvatarMotion(message.MotionName);
                return;
            }
            
            // 使用默认的Idle动画
            entity.ReplaceAvatarMotion(MotionName.FromMotion(MotionDef.Idle));
        }
    }
}