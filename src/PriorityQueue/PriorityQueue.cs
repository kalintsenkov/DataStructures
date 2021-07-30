namespace PriorityQueue
{
    using System;
    using Common;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        public int Size => throw new NotImplementedException();

        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Add(T element)
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }
    }
}
