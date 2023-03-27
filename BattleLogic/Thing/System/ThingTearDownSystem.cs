//------------------------------------------------------------
//        File:  ThingTearDownSystem.cs
//       Brief:  ThingTearDownSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-27
//============================================================

using Battle.Logic.Base.CSExtension;

namespace Battle.Logic.Thing.System
{
    internal class ThingTearDownSystem : LogicTearDownSystem
    {
        public ThingTearDownSystem(LogicContexts contexts) : base(contexts) {
        }

        public override void TearDown() {
            foreach (var thingEntity in Contexts.logicThing.GetEntities()) {
                thingEntity.Destroy();
            }
        }
    }
}