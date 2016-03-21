using System;

namespace Code
{
    public static class Question2_2
    {
        // 2.2 Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.

        // Space: O(1)
        // Time: O(N)
        public static Node<T> FindKthToLast<T>(Node<T> head, int k) where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            if (k < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(k), "Value must be greater than or equal to zero");
            }

            var result = head;

            for (int i = 0; i < k; i++)
            {
                head = head.Next;

                if (head == null)
                {
                    throw new ArgumentOutOfRangeException(nameof(k), "There must be at least k elements in the list");
                }
            }

            while (head.Next != null)
            {
                head = head.Next;
                result = result.Next;
            }

            return result;
        }
    }
}
