namespace BinarySearchTree.Tests
{
    using Common;
    using NUnit.Framework;

    public class Tests
    {
        private IAbstractBinarySearchTree<int> bst;

        [SetUp]
        public void InitializeBinarySearchTree()
        {
            //            12
            //      5           21
            //  1      8    18      23

            this.bst = new BinarySearchTree<int>();
            this.bst.Insert(12);
            this.bst.Insert(21);
            this.bst.Insert(5);
            this.bst.Insert(1);
            this.bst.Insert(8);
            this.bst.Insert(18);
            this.bst.Insert(23);
        }


        [Test]
        public void TestLeftSideBinarySearchTree()
        {
            var root = this.bst.Root;
            var left = root.LeftChild;
            var leftLeft = left.LeftChild;
            var leftRight = left.RightChild;

            Assert.AreEqual(12, root.Value);
            Assert.AreEqual(5, left.Value);
            Assert.AreEqual(1, leftLeft.Value);
            Assert.AreEqual(8, leftRight.Value);
        }

        [Test]
        public void TestRightSideBinarySearchTree()
        {
            var root = this.bst.Root;
            var right = root.RightChild;
            var rightLeft = right.LeftChild;
            var rightRight = right.RightChild;

            Assert.AreEqual(12, root.Value);
            Assert.AreEqual(21, right.Value);
            Assert.AreEqual(18, rightLeft.Value);
            Assert.AreEqual(23, rightRight.Value);
        }

        [Test]
        public void TestSearchCheckReturnedTreeStructure()
        {
            var searched = this.bst.Search(5);
            var root = searched.Root;
            var left = root.LeftChild;
            var right = root.RightChild;

            Assert.AreEqual(5, root.Value);
            Assert.AreEqual(1, left.Value);
            Assert.AreEqual(8, right.Value);
        }

        [Test]
        public void TestSearchCheckReturnedTreeStructureWithOnlyLeftNode()
        {
            this.bst.Insert(-2);
            var searched = this.bst.Search(1);
            var root = searched.Root;
            var left = root.LeftChild;
            var right = root.RightChild;

            Assert.AreEqual(1, root.Value);
            Assert.AreEqual(-2, left.Value);
            Assert.AreEqual(null, right);
        }

        [Test]
        public void TestContainsCheckReturnedTrue() => Assert.IsTrue(this.bst.Contains(1));

        [Test]
        public void TestContainsCheckReturnedFalse() => Assert.IsFalse(this.bst.Contains(77));
    }
}