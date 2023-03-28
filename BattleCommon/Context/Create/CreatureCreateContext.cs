//------------------------------------------------------------
//        File:  CreatureCreateContext.cs
//       Brief:  CreatureCreateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-28
//============================================================

using Battle.Common.Context.Combat;

namespace Battle.Common.Context.Create
{
    public class CreatureCreateContext : ThingCrateContext
    {
        public CombatValue CombatValue = new CombatValue();
    }
}