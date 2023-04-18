//------------------------------------------------------------
//        File:  UniqueIdGenerator.cs
//       Brief:  UniqueIdGenerator
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-18
//============================================================

namespace Battle.View.Base
{
    internal class UniqueIdGenerator
    {
        private ulong _independentId = ulong.MaxValue; // View需要从最大开始递减, 避免跟Logic中的Id重复
        
        public ulong IndependentId => --_independentId;
    }
}