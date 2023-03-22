//------------------------------------------------------------
//        File:  LogicSystems.cs
//       Brief:  LogicSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Logic
{
    public class LogicSystems : Feature
    {
        public LogicSystems(LogicContexts contexts) {
            
        }

        public override void TearDown() {
            DeactivateReactiveSystems();
            base.TearDown();
        }
    }
}