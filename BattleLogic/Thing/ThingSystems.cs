//------------------------------------------------------------
//        File:  ThingSystems.cs
//       Brief:  ThingSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using Battle.Logic.Thing.Behaviour.State.Cast.System;
using Battle.Logic.Thing.Behaviour.State.Idle.System;
using Battle.Logic.Thing.System;
using Battle.Logic.Thing.System.Gamer;

namespace Battle.Logic.Thing
{
    internal sealed class ThingSystems : Feature
    {
        public ThingSystems(LogicContexts contexts) {
            // Initialize Systems 
            Add(new InitializeGamerGroupSystem(contexts));
            Add(new ThingPositionUpdatedSystem(contexts));
            Add(new ThingRotationUpdatedSystem(contexts));
            Add(new ThingHpUpdatedSystem(contexts));
            
            // Reactive Systems
            Add(new UpdateIdleMotionSystem(contexts));
            Add(new ExitCastStateOnFinishedSystem(contexts));
            
            // Teardown Systems
            Add(new ThingTearDownSystem(contexts));
        }
    }
}