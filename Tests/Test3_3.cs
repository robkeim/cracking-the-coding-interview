using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test3_3
    {
        [TestMethod]
        public void BasicTest()
        {
            var stack = new SetOfStacks<int>();

            const int N = 100;
            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            for (int i = N; i > 0; i--)
            {
                Assert.AreEqual(i - 1, stack.Pop());
            }

            stack.Push(0);
            Assert.AreEqual(0, stack.Pop());
        }

        [TestMethod]
        public void InvalidOperationsTest()
        {
            var stack = new SetOfStacks<int>();

            TestHelpers.AssertExceptionThrown(() => stack.Pop(), typeof(InvalidOperationException));
        }
    }
}
