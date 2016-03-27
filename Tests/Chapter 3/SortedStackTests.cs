using System;
using System.Linq;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SortedStackTests
    {
        [TestMethod]
        public void BasicTest()
        {
            var stack = new SortedStack<int>();

            PushMany(stack, 1, 3, 7, 6, 2, 9, 4, 0, 8, 5);
            Validate(stack, Enumerable.Range(0, 10).ToArray());

            // Repeated values
            PushMany(stack, 2, 1, 3, 2, 2);
            Validate(stack, 1, 2, 2, 2, 3);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            var stack = new SortedStack<int>();

            TestHelpers.AssertExceptionThrown(() => stack.Peek(), typeof(InvalidOperationException));
            TestHelpers.AssertExceptionThrown(() => stack.Pop(), typeof(InvalidOperationException));
        }

        private static void PushMany<T>(SortedStack<T> stack, params T[] values)
            where T : IComparable<T>
        {
            foreach (var value in values)
            {
                stack.Push(value);
            }
        }

        private static void Validate<T>(SortedStack<T> stack, params T[] expectedValues)
            where T : IComparable<T>
        {
            foreach (var value in expectedValues)
            {
                Assert.IsFalse(stack.IsEmpty());
                Assert.AreEqual(value, stack.Pop());
            }

            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
