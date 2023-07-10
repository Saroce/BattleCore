//------------------------------------------------------------
//        File:  MonsterCreateContext.cs
//       Brief:  MonsterCreateContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-10
//============================================================

using Battle.Common.Constant;

namespace Battle.Common.Context.Create
{
    public class MonsterCreateContext : CreatureCreateContext
    {
        public int MonsterId;

        public MonsterCreateContext() {
            ThingType = ThingType.Monster;
        }
    }
}