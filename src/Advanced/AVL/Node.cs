namespace AVL
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        public Node(
            T value,
            Node<T> left = null,
            Node<T> right = null,
            int height = 1,
            int balance = 0)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
            this.Height = height;
            this.Balance = balance;
        }

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int Height { get; set; }

        public int Balance { get; set; }
    }
}
