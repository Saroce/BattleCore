//------------------------------------------------------------
//        File:  IMessageQueue.cs
//       Brief:  IMessageQueue
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

namespace Battle.Common.Context
{
    public interface IMessageQueue<T>
    {
        void Enqueue(T obj);

        bool TryDequeue(out T obj);
    }
}