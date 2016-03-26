using System;

namespace Code
{
    public static class Question2_6
    {
        // 2.6 Palindrome: Implement a funciton to check if a linked lits is a palindrome.

        // Space: O(N)
        // Time: O(N)
        public static bool IsPalindrome<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var reverse = ReverseAndClone(head);

            while (head != null && reverse != null)
            {
                if (!head.Data.Equals(reverse.Data))
                {
                    return false;
                }

                head = head.Next;
                reverse = reverse.Next;
            }

            return head == null && reverse == null;
        }

        private static Node<T> ReverseAndClone<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            Node<T> next = null;

            while (head != null)
            {
                var tmp = new Node<T>(head.Data);
                tmp.Next = next;
                next = tmp;

                head = head.Next;
            }

            return next;
        }
    }
}
