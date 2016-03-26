using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test2_8
    {
        [TestMethod]
        public void BasicTest()
        {
            var list = TestHelpers.CreateLinkedList(1, 2, 3);
            var loopStart = AddLoop(list, 4, 5, 6);
            Validate(list, loopStart);

            // Loop of size one
            list = TestHelpers.CreateLinkedList(1, 2, 3);
            loopStart = AddLoop(list, 4);
            Validate(list, loopStart);

            // Loop is first item in the list
            loopStart = AddLoop(null, 1, 2, 3);
            Validate(loopStart, loopStart);
        }

        [TestMethod]
        public void InvalidInput()
        {
            TestHelpers.AssertExceptionThrown(() => Question2_8.FindLoopStart<int>(null), typeof(ArgumentNullException));
        }

        private static Node<T> AddLoop<T>(Node<T> head, params T[] loop)
            where T : IEquatable<T>
        {
            while (head?.Next != null)
            {
                head = head.Next;
            }

            var loopStart = TestHelpers.CreateLinkedList(loop);
            var loopEnd = loopStart;

            while (loopEnd.Next != null)
            {
                loopEnd = loopEnd.Next;
            }

            if (head != null)
            {
                head.Next = loopStart;
            }

            loopEnd.Next = loopStart;

            return loopStart;
        }

        private static void Validate<T>(Node<T> head, Node<T> loopStart)
            where T : IEquatable<T>
        {
            Assert.AreEqual(loopStart, Question2_8.FindLoopStart(head));
        }
    }
}
