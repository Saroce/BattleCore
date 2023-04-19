//------------------------------------------------------------
//        File:  BattleException.cs
//       Brief:  BattleException
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-19
//============================================================

using System;

namespace Battle.Common.Exceptions
{
    public class BattleException : Exception
    {
        public BattleException() {
            
        }

        public BattleException(string message) : base(message) {
            
        }
    }
}