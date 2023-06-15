//------------------------------------------------------------
//        File:  ViewSystems.cs
//       Brief:  ViewSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Battle.View.HUD;
using Battle.View.Input;
using Battle.View.Skill;
using Battle.View.Thing;

namespace Battle.View
{
    public class ViewSystems : Feature
    {
        public ViewSystems(ViewContexts contexts) {
            Add(new InputSystems(contexts));
            Add(new ThingSystems(contexts));
            Add(new SkillSystems(contexts));
            Add(new HUDSystems(contexts));
        }

        public override void TearDown() {
            DeactivateReactiveSystems();
            base.TearDown();
        }
    }
}