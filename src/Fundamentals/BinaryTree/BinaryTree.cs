namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class BinaryTree<T>
    {
        public BinaryTree(Node<T> root)
            => this.Root = root;

        public Node<T> Root { get; }

        public string AsIndentedPreOrder(int indent)
            => this.Root.DfsPreOrder(indent);

        public List<Node<T>> InOrder()
            => this.Root.DfsInOrder().ToList();

        public List<Node<T>> PostOrder()
            => this.Root.DfsPostOrder().ToList();

        public List<Node<T>> PreOrder()
            => this.Root.DfsPreOrder().ToList();

        public void ForEachInOrder(Action<T> action)
            => this.Root.DfsInOrder(action);
    }
}
