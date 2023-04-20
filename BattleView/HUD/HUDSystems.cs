//------------------------------------------------------------
//        File:  HUDSystems.cs
//       Brief:  HUDSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-20
//============================================================

using Battle.View.HUD.System;

namespace Battle.View.HUD
{
    internal sealed class HUDSystems : Feature
    {
        public HUDSystems(ViewContexts contexts) {
            // Reactive Systems
            Add(new AddHUDViewSystem(contexts));

            // Execute Systems
            Add(new HUDSyncPositionSystem(contexts));
        }
    }
}