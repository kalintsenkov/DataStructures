namespace BinarySearchTree
{
    using System;
    using Common;

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
            : this()
            => this.Root = root;

        public Node<T> Root { get; private set; }

        public bool Contains(T value)
            => this.Contains(value, this.Root);

        public void Insert(T value)
            => this.Insert(value, this.Root);

        public BinarySearchTree<T> Search(T value)
            => this.Search(value, this.Root);

        private bool Contains(T value, Node<T> node)
        {
            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftChild != null)
                {
                    return this.Contains(value, node.LeftChild);
                }
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                if (node.RightChild != null)
                {
                    return this.Contains(value, node.RightChild);
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        private void Insert(T value, Node<T> node)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(value);
                return;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(value);
                    return;
                }

                this.Insert(value, node.LeftChild);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(value);
                    return;
                }

                this.Insert(value, node.RightChild);
            }
        }

        private BinarySearchTree<T> Search(T value, Node<T> node)
        {
            if (node.Value.CompareTo(value) > 0)
            {
                if (node.LeftChild != null)
                {
                    return this.Search(value, node.LeftChild);
                }
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                if (node.RightChild != null)
                {
                    return this.Search(value, node.RightChild);
                }
            }
            else
            {
                return new BinarySearchTree<T>(node);
            }

            return null;
        }
    }
}
