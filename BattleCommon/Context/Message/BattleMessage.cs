//------------------------------------------------------------
//        File:  BattleMessage.cs
//       Brief:  BattleMessage
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-24
//============================================================

namespace Battle.Common.Context.Message
{
    public class BattleMessage : IBattleMessage
    {
        public int FrameIndex { get; set; }
    }
}