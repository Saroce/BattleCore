//------------------------------------------------------------
//        File:  UniqueIdGenerator.cs
//       Brief:  UniqueIdGenerator
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-07-05
//============================================================

namespace Battle.Common
{
    internal static class UniqueIdGenerator
    {
        private static int _id;

        public static int Id => ++_id;
    }
}