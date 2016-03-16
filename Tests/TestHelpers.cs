using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public static class TestHelpers
    {
        // This is used instead of the ExpectedException test attribute to allow testing multiple exceptions
        // in the same test
        public static void AssertExceptionThrown(Action action, Type type)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                if (e.GetType() != type)
                {
                    Assert.Fail("Unexpected type of exception={0}", e.GetType());
                }

                return;
            }

            Assert.Fail("No exception thrown");
        }

        // Creates a two dimensional matrix from a one dimensional input
        // Example input:
        // 1 2 3 4 5 6 7 8 9
        // Example output:
        // 1 2 3
        // 4 5 6
        // 7 8 9
        public static T[,] CreateTwoDimensionalMatrix<T>(params T[] list)
        {
            var size = GetMatrixSize(list);

            var result = new T[size, size];
            var counter = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = list[counter++];
                }
            }

            return result;
        }
        
        public static Node<T> CloneList<T>(Node<T> head) where T : class
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

        public static Node<T> CreateLinkedList<T>(params T[] values) where T : class
        {
            Node<T> head = new Node<T>(values[0]);
            Node<T> cur = head;

            for (int i = 1; i < values.Length; i++)
            {
                Node<T> next = new Node<T>(values[i]);
                cur.Next = next;
                cur = cur.Next;
            }

            return head;
        } 

        public static void ValidateLinkedListContent<T>(Node<T> head, params T[] values) where T : class
        {
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

        private static int GetMatrixSize<T>(params T[] list)
        {
            var length = Math.Sqrt(list.Length);

            if (length % 1 != 0)
            {
                throw new ArgumentException(nameof(list), "Number of elements must be a perfect square to create an NxN matrix");
            }

            return (int)length;
        }
    }
}
