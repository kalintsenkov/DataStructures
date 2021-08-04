namespace MaxHeap
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class MaxHeapTests
    {
        private MaxHeap<int> integerHeap;

        [SetUp]
        public void InitializeHeap()
            => this.integerHeap = new MaxHeap<int>();

        [Test]
        public void TestPeekShouldBeCorrect()
        {
            var elements = new List<int> { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var element in elements)
            {
                this.integerHeap.Add(element);
            }
            Assert.AreEqual(25, this.integerHeap.Peek());
        }

        [Test]
        public void TestPeekShouldThrowExceptionIfHeapIsEmpty()
        {
            Assert.Throws<IndexOutOfRangeException>(() => this.integerHeap.Peek());
        }

        [Test]
        public void TestHeapifyUpAddOne()
        {
            this.integerHeap.Add(13);
            Assert.AreEqual(13, this.integerHeap.Peek());
        }

        [Test]
        public void TestHeapifyUpAddMany()
        {
            var elements = new List<int> { 15, 6, 9, 5, 25, 8, 17, 16 };
            foreach (var element in elements)
            {
                this.integerHeap.Add(element);
            }
            Assert.AreEqual(25, this.integerHeap.Peek());
        }

        [Test]
        public void TestSizeShouldBeCorrect()
        {
            var elements = new List<int> { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var element in elements)
            {
                this.integerHeap.Add(element);
            }
            Assert.AreEqual(8, this.integerHeap.Size);
        }
    }
}