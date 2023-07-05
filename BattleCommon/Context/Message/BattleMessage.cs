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
    public class BattleMessage<T> : IBattleMessage where T : class
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        private static int _id = UniqueIdGenerator.Id;
        
        public int FrameIndex { get; set; }

        public int MessageId { get; } = _id;
    }
}