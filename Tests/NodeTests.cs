using System;
using System.Runtime.Remoting.Messaging;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void BasicTest()
        {
            // Add an element
            Node<string> head = new Node<string>("a");
            ValidateResult(head, "a");

            // Add two more elements
            head.AppendToTail("b");
            head.AppendToTail("c");
            ValidateResult(head, "a", "b", "c");

            // Remove the middle element
            head = head.DeleteNode(head, "b");
            ValidateResult(head, "a", "c");
        }

        [TestMethod]
        public void RemoveTests()
        {
            // Add three elements
            Node<string> head = new Node<string>("a");
            head.AppendToTail("b");
            head.AppendToTail("c");
            ValidateResult(head, "a", "b", "c");

            // Remove the middle one
            head = head.DeleteNode(head, "b");
            ValidateResult(head, "a", "c");

            // Remove the first one
            head = head.DeleteNode(head, "a");
            ValidateResult(head, "c");

            // Remove non-existent node
            head = head.DeleteNode(head, "d");
            ValidateResult(head, "c");
        }

        private void ValidateResult<T>(Node<T> node, params T[] values) where T : class
        {
            Assert.IsNotNull(node);

            var numElements = values.Length;
            var count = 0;

            while (count < numElements && node != null)
            {
                Assert.AreEqual(values[count], node.Data);
                count++;
                node = node.Next;
            }

            Assert.IsNull(node);
            Assert.AreEqual(numElements, count);
        }
    }
}
