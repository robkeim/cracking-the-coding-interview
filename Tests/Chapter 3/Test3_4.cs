using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test3_4
    {
        [TestMethod]
        public void BasicTest()
        {
            var queue = new MyQueue<int>();

            queue.Add(1);
            queue.Add(2);

            Assert.AreEqual(1, queue.Remove());
            Assert.AreEqual(2, queue.Remove());

            queue.Add(3);
            Assert.AreEqual(3, queue.Remove());

            queue.Add(4);
            queue.Add(5);

            Assert.AreEqual(4, queue.Remove());
            Assert.AreEqual(5, queue.Remove());
        }

        [TestMethod]
        public void InvalidOperationsTest()
        {
            var queue = new MyQueue<int>();

            TestHelpers.AssertExceptionThrown(() => queue.Remove(), typeof(InvalidOperationException));
        }
    }
}
