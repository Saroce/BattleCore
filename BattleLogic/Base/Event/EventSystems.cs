//------------------------------------------------------------
//        File:  EventSystems.cs
//       Brief:  EventSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.Event.System;

namespace Battle.Logic.Base.Event
{
    internal sealed class EventSystems : Feature
    {
        public EventSystems(LogicContexts contexts) {
            Add(new DestroyEventSystem(contexts));
            Add(new CleanupEventSystem(contexts));
            Add(new TearDownEventSystem(contexts));
        }
    }
}