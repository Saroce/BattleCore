//------------------------------------------------------------
//        File:  BattleContext.cs
//       Brief:  BattleContext
//
//      Author:  Saroce, Saroce233@163.com 
//
//    Modified:  2023-03-21
//============================================================

using Battle.Common.Context.Combat;
using Core.Lite.DataSystem;
using Core.Lite.RefPool;

namespace Battle.Logic.Base
{
    public sealed class BattleContext
    {
        public int FrameDeltaInMilliseconds;
        public int Seed;
        public GamerGroup GamerGroup;

        public string ConfigPath;
        public IRefPoolManager RefPoolManager;
        public IDataReader DataReader;
    }
}