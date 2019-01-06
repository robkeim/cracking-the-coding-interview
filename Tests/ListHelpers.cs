using System;
using System.Collections.Generic;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public static class ListHelpers
    {
        public static Node<T> CloneList<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                return null;
            }

            var result = new Node<T>(head.Data);
            var curResult = result;
            head = head.Next;

            while (head != null)
            {
                curResult.AppendToTail(head.Data);
                curResult = result.Next;
                head = head.Next;
            }

            return result;
        }

        public static Node<T> CreateLinkedList<T>(params T[] values)
            where T : IEquatable<T>
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var head = new Node<T>(values[0]);
            Node<T> cur = head;

            for (int i = 1; i < values.Length; i++)
            {
                var next = new Node<T>(values[i]);
                cur.Next = next;
                cur = cur.Next;
            }

            return head;
        }

        public static void ValidateLinkedListContent<T>(Node<T> head, params T[] values)
            where T : IEquatable<T>
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            Assert.IsNotNull(head);

            var numElements = values.Length;
            var count = 0;

            while (count < numElements && head != null)
            {
                Assert.AreEqual(values[count], head.Data);
                count++;
                head = head.Next;
            }

            Assert.IsNull(head);
            Assert.AreEqual(numElements, count);
        }

        public static List<T> CreateList<T>(params T[] values)
        {
            return new List<T>(values);
        }
    }
}
