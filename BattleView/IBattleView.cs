//------------------------------------------------------------
//        File:  IBattleView.cs
//       Brief:  IBattleView
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Battle.Common.Context.Message;
using Core.Lite.Base;

namespace Battle.View
{
    public interface IBattleView : IBaseObject<object>
    {
        void EnterFrame();

        void EnqueueMessage(IBattleMessage message);
    }
}