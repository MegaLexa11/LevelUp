using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitedQueueProject
{
    internal class LimitedQueue<T> : IEnumerable
    {
        private readonly Queue<T> _queue = new Queue<T>();

        public int QueueLimit { get; }

        public LimitedQueue(int limit)
        {
            QueueLimit = limit;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enqueue(T item)
        {
            if (_queue.Count >= QueueLimit)
            {
                throw new Exception($"Can't add any object! The limit of queue is {QueueLimit}.");
            }
            _queue.Enqueue(item);
        }

        public T Dequeue()
        {
             return _queue.Dequeue();
        }
    }
}
