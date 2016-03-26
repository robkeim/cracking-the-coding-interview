using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test3_2
    {
        [TestMethod]
        public void BasicTest()
        {
            var stack = new MinStack<int>();

            // Build stack
            PushAndValidateMin(stack, 1, 1);
            PushAndValidateMin(stack, 2, 1);

            // Empty stack
            PopAndValidateMin(stack, 2, 1);
            Assert.AreEqual(1, stack.Pop());

            // Build stack
            PushAndValidateMin(stack, 3, 3);
            PushAndValidateMin(stack, 2, 2);
            PushAndValidateMin(stack, 4, 2);
            PushAndValidateMin(stack, 1, 1);

            // Empty stack
            PopAndValidateMin(stack, 1, 2);
            PopAndValidateMin(stack, 4, 2);
            PopAndValidateMin(stack, 2, 3);
            Assert.AreEqual(3, stack.Pop());
        }

        [TestMethod]
        public void InvalidOperationsTest()
        {
            var stack = new MinStack<int>();

            TestHelpers.AssertExceptionThrown(() => stack.Min(), typeof(InvalidOperationException));
            TestHelpers.AssertExceptionThrown(() => stack.Pop(), typeof(InvalidOperationException));
        }

        private static void PushAndValidateMin<T>(MinStack<T> stack, T item, T minAfterPush)
            where T : IComparable<T>
        {
            stack.Push(item);
            Assert.AreEqual(minAfterPush, stack.Min());
        }

        private static void PopAndValidateMin<T>(MinStack<T> stack, T poppedItem, T minAfterPop)
            where T : IComparable<T>
        {
            Assert.AreEqual(poppedItem, stack.Pop());
            Assert.AreEqual(minAfterPop, stack.Min());
        }
    }
}