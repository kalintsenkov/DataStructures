namespace Common
{
    using System;
    using System.Collections.Generic;

    public static class NodeDfsExtensions
    {
        public static IEnumerable<Node<T>> DfsPreOrder<T>(this Node<T> node)
        {
            var list = new List<Node<T>>();

            list.Add(node);

            if (node.LeftChild != null)
            {
                list.AddRange(node.LeftChild.DfsPreOrder());
            }

            if (node.RightChild != null)
            {
                list.AddRange(node.RightChild.DfsPreOrder());
            }

            return list;
        }

        public static string DfsPreOrder<T>(this Node<T> node, int indent)
        {
            var result = $"{new string(' ', indent)}{node.Value}{Environment.NewLine}";

            if (node.LeftChild != null)
            {
                result += node.LeftChild.DfsPreOrder(indent + 2);
            }

            if (node.RightChild != null)
            {
                result += node.RightChild.DfsPreOrder(indent + 2);
            }

            return result;
        }

        public static IEnumerable<Node<T>> DfsPostOrder<T>(this Node<T> node)
        {
            var list = new List<Node<T>>();

            if (node.LeftChild != null)
            {
                list.AddRange(node.LeftChild.DfsPostOrder());
            }

            if (node.RightChild != null)
            {
                list.AddRange(node.RightChild.DfsPostOrder());
            }

            list.Add(node);

            return list;
        }

        public static IEnumerable<Node<T>> DfsInOrder<T>(this Node<T> node)
        {
            var list = new List<Node<T>>();

            if (node.LeftChild != null)
            {
                list.AddRange(node.LeftChild.DfsInOrder());
            }

            list.Add(node);

            if (node.RightChild != null)
            {
                list.AddRange(node.RightChild.DfsInOrder());
            }

            return list;
        }

        public static void DfsInOrder<T>(this Node<T> node, Action<T> action)
        {
            node.LeftChild?.DfsInOrder(action);

            action(node.Value);

            node.RightChild?.DfsInOrder(action);
        }
    }
}
