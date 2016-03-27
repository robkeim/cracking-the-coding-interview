using System;
using System.Collections.Generic;
using System.Linq;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test3_5
    {
        [TestMethod]
        public void BasicTest()
        {
            var stack = CreateStack(1, 4, 5, 3, 2);
            Question3_5.SortStack(stack);
            Validate(stack, 1, 2, 3, 4, 5);

            // Duplicated values
            stack = CreateStack(3, 4, 1, 2, 3);
            Question3_5.SortStack(stack);
            Validate(stack, 1, 2, 3, 3, 4);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            TestHelpers.AssertExceptionThrown(() => Question3_5.SortStack<int>(null), typeof(ArgumentNullException));
        }

        private static void Validate<T>(Stack<T> stack, params T[] expectedValues)
        {
            foreach (var value in expectedValues)
            {
                Assert.IsFalse(stack.Count == 0);
                Assert.AreEqual(value, stack.Pop());
            }

            Assert.IsTrue(stack.Count == 0);
        }

        private static Stack<T> CreateStack<T>(params T[] stack)
        {
            var result = new Stack<T>(stack.Length);
            stack = stack.Reverse().ToArray();

            foreach (var item in stack)
            {
                result.Push(item);
            }

            return result;
        }
    }
}
