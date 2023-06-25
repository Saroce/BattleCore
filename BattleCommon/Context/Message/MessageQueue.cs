//------------------------------------------------------------
//        File:  MessageQueue.cs
//       Brief:  MessageQueue
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using System.Collections.Concurrent;
using System.Collections.Generic;
using Core.Lite.Loggers;

namespace Battle.Common.Context.Message
{
    public class MessageQueue<T> : IMessageQueue<T> where T : class
    {
#if ENABLE_LOGIC_THREAD
        private readonly ConcurrentQueue<T> _queue;

        public MessageQueue() {
            _queue = new ConcurrentQueue<T>();
        }

        public void Enqueue(T obj) {
            if (obj == null) {
                Logger.Error("Enqueue obj cannot be null.");
                return;
            }
            _queue.Enqueue(obj);
        }

        public bool TryDequeue(out T obj) {
            return _queue.TryDequeue(out obj);
        }
#else
        private readonly Queue<T> _queue;

        public MessageQueue() {
            _queue = new Queue<T>(512);
        }

        public void Enqueue(T obj) {
            if (obj == null) {
                Logger.Error("Enqueue obj cannot be null.");
                return;
            }

            _queue.Enqueue(obj);
        }

        public bool TryDequeue(out T obj) {
            if (_queue.Count <= 0) {
                obj = default;
                return false;
            }

            obj = _queue.Dequeue();
            return true;
        }
#endif
    }
}