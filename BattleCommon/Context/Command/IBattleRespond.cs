//------------------------------------------------------------
//        File:  IBattleRespond.cs
//       Brief:  IBattleRespond
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using System.Collections;

namespace Battle.Common.Context.Command
{
    public interface IBattleRespond
    {
        IEnumerator Receive();
        
        bool Result { get; }
        
        string ErrorMessage { get; }
    }
}