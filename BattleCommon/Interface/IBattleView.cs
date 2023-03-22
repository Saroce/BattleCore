//------------------------------------------------------------
//        File:  IBattleView.cs
//       Brief:  IBattleView
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using Core.Lite.Base;

namespace Battle.Common.Interface
{
    public interface IBattleView : IBaseObject<object>
    {
        void EnterFrame();

        void EnqueueMessage(IBattleMessage message);
    }
}