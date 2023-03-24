//------------------------------------------------------------
//        File:  IBattleLogic.cs
//       Brief:  IBattleLogic
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Battle.Common.Context.Command;
using Battle.Common.Context.Message;
using Core.Lite.Base;

namespace Battle.Logic
{
    public interface IBattleLogic : IBaseObject<object>
    {
        void EnterFrame();
        
        void Poll();
        
        bool TryDequeueMessage(out IBattleMessage message);

        void EnqueueRequest(IBattleRequest request);
    }
}