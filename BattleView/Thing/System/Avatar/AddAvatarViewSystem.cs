//------------------------------------------------------------
//        File:  AddAvatarViewSystem.cs
//       Brief:  AddAvatarViewSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-19
//============================================================

using System.Collections.Generic;
using Battle.View.Base.System;
using Entitas;

namespace Battle.View.Thing.System.Avatar
{
    internal class AddAvatarViewSystem : ViewReactiveSystem<ViewThingEntity>
    {
        public AddAvatarViewSystem(ViewContexts contexts) : base(contexts, contexts.viewThing) {
            
        }

        protected override ICollector<ViewThingEntity> GetTrigger(IContext<ViewThingEntity> context) {
            
        }

        protected override bool Filter(ViewThingEntity entity) {
            
        }

        protected override void Execute(List<ViewThingEntity> entities) {
            
        }
    }
}