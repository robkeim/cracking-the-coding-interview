using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test2_7
    {
        [TestMethod]
        public void BasicTest()
        {
            var list1 = TestHelpers.CreateLinkedList(1, 2, 3);
            var list2 = TestHelpers.CreateLinkedList(4, 5, 6);
            var intersection = TestHelpers.CreateLinkedList(7, 8, 9);
            AddIntersection(list1, list2, intersection);
            Validate(list1, list2, intersection);

            // Different sized lists
            list1 = TestHelpers.CreateLinkedList(1);
            list2 = TestHelpers.CreateLinkedList(2, 3);
            intersection = TestHelpers.CreateLinkedList(4, 5, 6);
            AddIntersection(list1, list2, intersection);
            Validate(list1, list2, intersection);

            // Intersection is last node
            list1 = TestHelpers.CreateLinkedList(1, 2);
            list2 = TestHelpers.CreateLinkedList(3, 4, 5);
            intersection = TestHelpers.CreateLinkedList(6);
            AddIntersection(list1, list2, intersection);
            Validate(list1, list2, intersection);

            // Repeated values (to ensure references are being computed)
            list1 = TestHelpers.CreateLinkedList(1, 3);
            list2 = TestHelpers.CreateLinkedList(2, 2, 2);
            intersection = TestHelpers.CreateLinkedList(2);
            AddIntersection(list1, list2, intersection);
            Validate(list1, list2, intersection);

            // No intersection
            list1 = TestHelpers.CreateLinkedList(1, 2, 3);
            list2 = TestHelpers.CreateLinkedList(4, 5, 6);
            Validate(list1, list2, null);
        }

        [TestMethod]
        public void InvalidInputsTest()
        {
            var head = new Node<int>(1);

            TestHelpers.AssertExceptionThrown(() => Question2_7.FindIntersection(null, head), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question2_7.FindIntersection(head, null), typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => Question2_7.FindIntersection<int>(null, null), typeof(ArgumentNullException));
        }

        private static void AddIntersection<T>(Node<T> list1, Node<T> list2, Node<T> intersection)
            where T : IEquatable<T>
        {
            while (list1.Next != null)
            {
                list1 = list1.Next;
            }

            list1.Next = intersection;

            while (list2.Next != null)
            {
                list2 = list2.Next;
            }

            list2.Next = intersection;
        }

        private static void Validate<T>(Node<T> list1, Node<T> list2, Node<T> intersection)
            where T : IEquatable<T>
        {
            Assert.IsTrue(ReferenceEquals(intersection, Question2_7.FindIntersection(list1, list2)));
        }
    }
}
