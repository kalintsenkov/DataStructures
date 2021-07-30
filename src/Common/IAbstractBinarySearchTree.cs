namespace Common
{
    using System;

    public interface IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        T Value { get; }

        Node<T> Root { get; }

        void Insert(T value);

        bool Contains(T value);

        IAbstractBinarySearchTree<T> Search(T value);
    }
}
