namespace BinaryTree.Tests
{
    using System;
    using System.Text;
    using Common;
    using NUnit.Framework;

    public class BinaryTreeTests
    {
        private IAbstractBinaryTree<int> tree;

        [SetUp]
        public void InitializeBinaryTree()
            => this.tree = new BinaryTree<int>(
                new Node<int>(17,
                    new Node<int>(9,
                        new Node<int>(3),
                        new Node<int>(11)),
                    new Node<int>(25,
                        new Node<int>(20),
                        new Node<int>(31))));

        [Test]
        public void TestAsIndentedPreOrder()
        {
            var actual = this.tree.AsIndentedPreOrder(0).Trim();

            var expected = "17\r\n" +
                           "  9\r\n" +
                           "    3\r\n" +
                           "    11\r\n" +
                           "  25\r\n" +
                           "    20\r\n" +
                           "    31";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestPreOrder()
        {
            var trees = this.tree.PreOrder();
            var expected = new[] { 17, 9, 3, 11, 25, 20, 31 };

            Assert.AreEqual(expected.Length, trees.Count);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], trees[i].Value);
            }
        }

        [Test]
        public void TestInOrder()
        {
            var trees = this.tree.InOrder();
            var expected = new[] { 3, 9, 11, 17, 20, 25, 31 };

            Assert.AreEqual(expected.Length, trees.Count);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], trees[i].Value);
            }
        }

        [Test]
        public void TestPostOrder()
        {
            var trees = this.tree.PostOrder();
            var expected = new[] { 3, 11, 9, 20, 31, 25, 17 };

            Assert.AreEqual(expected.Length, trees.Count);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], trees[i].Value);
            }
        }

        [Test]
        public void TestForEachInOrder()
        {
            var builder = new StringBuilder();
            this.tree.ForEachInOrder(key => builder.Append(key).Append(", "));

            var expected = "3, 9, 11, 17, 20, 25, 31";
            var actual = builder.ToString();

            Assert.IsTrue(builder.Length > 0);
            Assert.IsTrue(actual.Contains(", "));
            Assert.AreEqual(expected, actual.Substring(0, actual.LastIndexOf(", ", StringComparison.Ordinal)));
        }
    }
}