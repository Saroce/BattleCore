//------------------------------------------------------------
//        File:  IBattleLogic.cs
//       Brief:  IBattleLogic
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Core.Lite.Base;

namespace Battle.Common.Interface
{
    public interface IBattleLogic : IBaseObject<object>
    {
        void EnterFrame();
        
        void Poll();
        
        bool TryDequeueMessage(out IBattleMessage message);

        void EnqueueRequest(IBattleRequest request);
    }
}