//------------------------------------------------------------
//        File:  ExitCastStateOnFinishedSystem.cs
//       Brief:  ExitCastStateOnFinishedSystem
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-06-21
//============================================================

using Battle.Logic.Base.System;
using Battle.Logic.Common.Event.Skill;

namespace Battle.Logic.Thing.Behaviour.State.Cast.System
{
    internal class ExitCastStateOnFinishedSystem : LogicEventSystem<SkillCastFinishedEvent>
    {
        public ExitCastStateOnFinishedSystem(LogicContexts contexts) : base(contexts) {
        }

        protected override void OnEvent(SkillCastFinishedEvent context) {
            
        }
    }
}