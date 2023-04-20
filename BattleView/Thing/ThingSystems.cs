//------------------------------------------------------------
//        File:  ThingSystems.cs
//       Brief:  ThingSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-20
//============================================================

using Battle.View.Thing.System.Avatar;

namespace Battle.View.Thing
{
    public class ThingSystems : Feature
    {
        public ThingSystems(ViewContexts contexts) {
            
            // Reactive Systems
            Add(new AddAvatarViewSystem(contexts));
            Add(new ChangeMotionSystem(contexts));
            
            // Execute Systems
            Add(new SyncAvatarViewPositionSystem(contexts));
        }
    }
}