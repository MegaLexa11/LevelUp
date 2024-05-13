
using LimitedQueueProject;

LimitedQueue<int> customQueue = new LimitedQueue<int>(3);
customQueue.Enqueue(1);
customQueue.Enqueue(1);
customQueue.Enqueue(1);
customQueue.Dequeue();
customQueue.Enqueue(1);
customQueue.Enqueue(1);