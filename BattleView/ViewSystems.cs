//------------------------------------------------------------
//        File:  ViewSystems.cs
//       Brief:  ViewSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.View
{
    public class ViewSystems : Feature
    {
        public ViewSystems(ViewContexts contexts) {
            
        }

        public override void TearDown() {
            DeactivateReactiveSystems();
            base.TearDown();
        }
    }
}