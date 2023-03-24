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
        private static int _idGenerator = 0;

        public int GetMessageId() => ++_idGenerator;

        public int FrameIndex { get; set; }
    }
}