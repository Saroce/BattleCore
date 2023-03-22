//------------------------------------------------------------
//        File:  UniqueIdGenerator.cs
//       Brief:  UniqueIdGenerator
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Logic.Base
{
    public class UniqueIdGenerator
    {
        private ulong _independentId;

        public ulong IndependentId => ++_independentId;
    }
}