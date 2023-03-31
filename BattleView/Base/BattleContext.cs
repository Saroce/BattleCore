//------------------------------------------------------------
//        File:  BattleContext.cs
//       Brief:  BattleContext
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-22
//============================================================

using Core.Lite.RefPool;

namespace Battle.View.Base
{
    public sealed class BattleContext
    {
        public int Seed;
        
        public IRefPoolManager RefPoolManager;
    }
}