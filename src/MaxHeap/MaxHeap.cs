namespace MaxHeap
{
    using System;
    using Common;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        public int Size => throw new NotImplementedException();

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
