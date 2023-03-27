//------------------------------------------------------------
//        File:  ThingSystems.cs
//       Brief:  ThingSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using Battle.Logic.Thing.System;

namespace Battle.Logic.Thing
{
    internal sealed class ThingSystems : Feature
    {
        public ThingSystems(LogicContexts contexts) {
            
            // Teardown Systems
            Add(new ThingTearDownSystem(contexts));
        }
    }
}