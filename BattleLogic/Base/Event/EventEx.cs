//------------------------------------------------------------
//        File:  EventEx.cs
//       Brief:  EventEx
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

namespace Battle.Logic.Base.Event
{
    internal static class EventEx
    {
        /// <summary>
        /// 发送事件，主要用于战斗逻辑内部通讯
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="context"></param>
        public static void SendEvent(this LogicContexts contexts, IEventContext context) {
            var eventEntity = contexts.logicEvent.CreateEntity();
            eventEntity.AddEventFrameIndex(contexts.GetFrameCounter().FrameIndex);
            eventEntity.AddEventContext(context);
        }
    }
}