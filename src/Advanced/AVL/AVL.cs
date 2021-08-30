namespace AVL
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item) => this.Search(this.Root, item) != null;

        public void Insert(T item) => this.Root = this.Insert(this.Root, item);

        public void EachInOrder(Action<T> action) => this.EachInOrder(this.Root, action);

        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            var cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return this.Search(node.Left, item);
            }
            else if (cmp > 0)
            {
                return this.Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            var cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, item);
            }
            else
            {
                node.Right = this.Insert(node.Right, item);
            }

            this.UpdateFactors(node);

            return this.ReBalance(node);
        }

        private void UpdateFactors(Node<T> node)
        {
            var leftHeight = node.Left?.Height ?? 0;
            var rightHeight = node.Right?.Height ?? 0;

            node.Height = Math.Max(leftHeight, rightHeight) + 1;
            node.Balance = rightHeight - leftHeight;
        }

        private Node<T> ReBalance(Node<T> node)
        {
            if (node.Balance == -2)
            {
                node = node.Left.Balance > 0
                    ? this.LeftRightRotation(node)
                    : this.RightRightRotation(node);
            }
            if (node.Balance == 2)
            {
                node = node.Right.Balance < 0
                    ? this.RightLeftRotation(node)
                    : this.LeftLeftRotation(node);
            }

            return node;
        }

        private Node<T> LeftRightRotation(Node<T> node)
        {
            node.Left = this.LeftLeftRotation(node.Left);
            return this.RightRightRotation(node);
        }

        private Node<T> RightLeftRotation(Node<T> node)
        {
            node.Right = this.RightRightRotation(node.Right);
            return this.LeftLeftRotation(node);
        }

        private Node<T> LeftLeftRotation(Node<T> node) => this.LeftRotation(node);

        private Node<T> RightRightRotation(Node<T> node) => this.RightRotation(node);

        private Node<T> LeftRotation(Node<T> node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;

            this.UpdateFactors(node);
            this.UpdateFactors(newNode);

            return newNode;
        }

        private Node<T> RightRotation(Node<T> node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            this.UpdateFactors(node);
            this.UpdateFactors(newNode);

            return newNode;
        }
    }
}
