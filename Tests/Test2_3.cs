using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test2_3
    {
        [TestMethod]
        public void BasicTest()
        {
            // Remove first node
            var list = TestHelpers.CreateLinkedList(1, 2, 3);
            ValidateResult(list, list, 2, 3);

            // Remove middle node
            list = TestHelpers.CreateLinkedList(1, 2, 3);
            ValidateResult(list, list.Next, 1, 3);
        }

        [TestMethod]
        public void InvalidInputsTest()
        {
            // Null node
            TestHelpers.AssertExceptionThrown(() => { Question2_3.RemoveNode<int>(null); }, typeof(ArgumentException));

            // Node without next
            var node = new Node<int>(1);
            TestHelpers.AssertExceptionThrown(() => { Question2_3.RemoveNode(node); }, typeof(ArgumentException));
        }

        private void ValidateResult<T>(Node<T> list, Node<T> nodeToRemove, params T[] expectedResult) where T : IEquatable<T>
        {
            Question2_3.RemoveNode(nodeToRemove);
            TestHelpers.ValidateLinkedListContent(list, expectedResult);
        }
    }
}
