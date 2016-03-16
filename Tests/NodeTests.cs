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
            TestHelpers.ValidateLinkedListContent(head, "a");

            // Add two more elements
            head.AppendToTail("b");
            head.AppendToTail("c");
            TestHelpers.ValidateLinkedListContent(head, "a", "b", "c");

            // Remove the middle element
            head = head.DeleteNode(head, "b");
            TestHelpers.ValidateLinkedListContent(head, "a", "c");
        }

        [TestMethod]
        public void RemoveTests()
        {
            // Add three elements
            Node<string> head = new Node<string>("a");
            head.AppendToTail("b");
            head.AppendToTail("c");
            TestHelpers.ValidateLinkedListContent(head, "a", "b", "c");

            // Remove the middle one
            head = head.DeleteNode(head, "b");
            TestHelpers.ValidateLinkedListContent(head, "a", "c");

            // Remove the first one
            head = head.DeleteNode(head, "a");
            TestHelpers.ValidateLinkedListContent(head, "c");

            // Remove non-existent head
            head = head.DeleteNode(head, "d");
            TestHelpers.ValidateLinkedListContent(head, "c");
        }
    }
}
