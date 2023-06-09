﻿//------------------------------------------------------------
//        File:  IBattleMessage.cs
//       Brief:  IBattleMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Common.Context.Message
{
    public interface IBattleMessage
    {
        int FrameIndex { get; set; }

        int MessageId { get; }
    }
}