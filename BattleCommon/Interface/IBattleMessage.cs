//------------------------------------------------------------
//        File:  IBattleMessage.cs
//       Brief:  IBattleMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Common.Interface
{
    public interface IBattleMessage
    {
        int GetMessageId();
        
        int FrameIndex { get; set; }
    }
}