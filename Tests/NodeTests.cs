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
            Node<int> head = new Node<int>(1);
            TestHelpers.ValidateLinkedListContent(head, 1);

            // Add two more elements
            head.AppendToTail(2);
            head.AppendToTail(3);
            TestHelpers.ValidateLinkedListContent(head, 1, 2, 3);

            // Remove the middle element
            head = head.DeleteNode(head, 2);
            TestHelpers.ValidateLinkedListContent(head, 1, 3);
        }

        [TestMethod]
        public void RemoveTests()
        {
            // Add three elements
            Node<int> head = new Node<int>(1);
            head.AppendToTail(2);
            head.AppendToTail(3);
            TestHelpers.ValidateLinkedListContent(head, 1, 2, 3);

            // Remove the middle one
            head = head.DeleteNode(head, 2);
            TestHelpers.ValidateLinkedListContent(head, 1, 3);

            // Remove the first one
            head = head.DeleteNode(head, 1);
            TestHelpers.ValidateLinkedListContent(head, 3);

            // Remove non-existent head
            head = head.DeleteNode(head, 4);
            TestHelpers.ValidateLinkedListContent(head, 3);
        }
    }
}
