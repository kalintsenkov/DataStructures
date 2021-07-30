namespace Common
{
    using System;
    using System.Collections.Generic;

    public interface IAbstractBinaryTree<T>
    {
        Node<T> Root { get; }

        string AsIndentedPreOrder(int indent);

        List<Node<T>> PreOrder();

        List<Node<T>> InOrder();

        List<Node<T>> PostOrder();

        void ForEachInOrder(Action<T> action);
    }
}
