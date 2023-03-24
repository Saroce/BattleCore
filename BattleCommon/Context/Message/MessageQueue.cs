//------------------------------------------------------------
//        File:  MessageQueue.cs
//       Brief:  MessageQueue
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using System.Collections.Concurrent;

namespace Battle.Common.Context.Message
{
    public class MessageQueue<T> : IMessageQueue<T> where T : class
    {
        private readonly ConcurrentQueue<T> _queue;

        public MessageQueue() {
            _queue = new ConcurrentQueue<T>();
        }

        public void Enqueue(T obj) {
            if (obj == null) {
                // TODO 接上Log.Error
                return;
            }
            _queue.Enqueue(obj);
        }

        public bool TryDequeue(out T obj) {
            return _queue.TryDequeue(out obj);
        }
    }
}