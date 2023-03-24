//------------------------------------------------------------
//        File:  IBattleRequest.cs
//       Brief:  IBattleRequest
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Common.Context.Command
{
    public interface IBattleRequest
    {
        IBattleRespond GetRespond();
    }
}