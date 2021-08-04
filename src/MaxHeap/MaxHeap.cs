namespace MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> where T : IComparable<T>
    {
        private readonly List<T> heap = new();

        public int Size => this.heap.Count;

        public T Peek()
        {
            this.CheckSize();

            return this.heap[0];
        }

        public void Add(T value)
        {
            this.heap.Add(value);
            this.HeapifyUp(this.Size - 1);
        }

        public T Extract()
        {
            this.CheckSize();

            var max = this.heap[0];
            var last = this.heap[this.Size - 1];

            this.heap[0] = last;

            this.heap.Remove(last);

            this.HeapifyDown(this.Size - 1);

            return max;
        }

        private void HeapifyUp(int index)
        {
            if (index == 0)
            {
                return;
            }

            var parentIndex = this.GetParentIndex(index);

            if (this.heap[index].CompareTo(this.heap[parentIndex]) <= 0)
            {
                return;
            }

            this.Swap(index, parentIndex);

            this.HeapifyUp(parentIndex);
        }

        private void HeapifyDown(int index)
        {
            throw new NotImplementedException();
        }

        private void CheckSize()
        {
            if (this.Size == 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Swap(int index, int parentIndex)
            => (this.heap[index], this.heap[parentIndex]) = (this.heap[parentIndex], this.heap[index]);

        private int GetParentIndex(int index) => (index - 1) / 2;

        private int GetLeftChildIndex(int index) => 2 * index + 1;

        private int GetRightChildIndex(int index) => 2 * index + 2;
    }
}
