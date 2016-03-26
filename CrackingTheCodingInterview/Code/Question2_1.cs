using System;
using System.Collections.Generic;

namespace Code
{
    public static class Question2_1
    {
        // 2.1 Remove Dups: Write code to remove duplicates from an unsorted linked list.  FOLLOW UP How would you solve this problem if a temporary buffer is not allowed?

        // Space: O(N)
        // Time: O(N)
        public static void RemoveDuplicates<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var nodes = new HashSet<T>();
            nodes.Add(head.Data);

            while (head.Next != null)
            {
                if (nodes.Add(head.Next.Data))
                {
                    head = head.Next;
                }
                else
                {
                    head.Next = head.Next.Next;
                }
            }
        }

        // Space: O(1)
        // Time: O(N^2)
        public static void RemoveDuplicatesNoSpace<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            while (head != null)
            {
                var prev = head;
                var next = head.Next;
                while (next != null)
                {
                    if (next.Data.Equals(head.Data))
                    {
                        prev.Next = next.Next;
                        next = next.Next;
                    }
                    else
                    {
                        prev = next;
                        next = next.Next;
                    }
                }

                head = head.Next;
            }
        }
    }
}
