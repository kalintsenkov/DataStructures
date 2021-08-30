namespace Common
{
    using System.Collections.Generic;

    public static class NodeBfsExtensions
    {
        public static IEnumerable<Node<T>> Bfs<T>(this Node<T> node)
        {
            var list = new List<Node<T>>();

            var queue = new Queue<Node<T>>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                list.Add(currentNode);

                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                }
                if (currentNode.LeftChild != null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                }
            }

            return list;
        }
    }
}
