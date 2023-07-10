//------------------------------------------------------------
//        File:  LogicThingDef.cs
//       Brief:  LogicThingDef
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Entitas;

namespace Battle.Logic.Constant
{
    internal enum BehaviourType
    {
        Idle,
        Move,
        Cast,
        OutOfControl,
        Dead,
    }

    internal static class LogicThingDef
    {
        public static readonly IMatcher<LogicThingEntity> CreatureMatchers = LogicThingMatcher.AllOf(
            LogicThingMatcher.Id,
            LogicThingMatcher.Creature,
            LogicThingMatcher.ThingCreateContext,
            LogicThingMatcher.Position);
        
        public static readonly IMatcher<LogicThingEntity> GamerMatchers = LogicThingMatcher.AllOf(
            LogicThingMatcher.Id,
            LogicThingMatcher.Creature,
            LogicThingMatcher.Gamer,
            LogicThingMatcher.ThingCreateContext,
            LogicThingMatcher.Position);
    }
}
