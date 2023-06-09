﻿//------------------------------------------------------------
//        File:  LogicSystems.cs
//       Brief:  LogicSystems
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Battle.Logic.Base.Event;
using Battle.Logic.Buff;
using Battle.Logic.Effect;
using Battle.Logic.Input;
using Battle.Logic.Skill;
using Battle.Logic.Thing;

namespace Battle.Logic
{
    internal sealed class LogicSystems : Feature
    {
        public LogicSystems(LogicContexts contexts) {
            Add(new EventSystems(contexts));
            Add(new ThingSystems(contexts));
            Add(new InputSystems(contexts));
            Add(new BuffSystems(contexts));
            Add(new SkillSystems(contexts));
            Add(new EffectSystems(contexts));
        }

        public override void TearDown() {
            DeactivateReactiveSystems();
            base.TearDown();
        }
    }
}