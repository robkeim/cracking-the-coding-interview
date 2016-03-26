using System;

namespace Code
{
    public static class Question2_7
    {
        // 2.7 Intersection: Given two (singly) linked lists, determine if the two lists intersect.  Return th eintersection node.  Node that the intersection is defined based on reference, not value.  That is if the kth node of the first linked list is exactly the same node (by reference) as the jth node of the second linked list, then they are intersecting.

        // Space: O(1)
        // Time: O(N)
        public static Node<T> FindIntersection<T>(Node<T> list1, Node<T> list2)
            where T : IEquatable<T>
        {
            if (list1 == null)
            {
                throw new ArgumentNullException(nameof(list1));
            }

            if (list2 == null)
            {
                throw new ArgumentNullException(nameof(list2));
            }

            var list1Length = GetLength(list1);
            var list2Length = GetLength(list2);

            if (list1Length > list2Length)
            {
                for (int i = 0; i < list1Length - list2Length; i++)
                {
                    list1 = list1.Next;
                }
            }
            else
            {
                for (int i = 0; i < list2Length - list1Length; i++)
                {
                    list2 = list2.Next;
                }
            }

            while (list1 != null)
            {
                if (ReferenceEquals(list1, list2))
                {
                    return list1;
                }

                list1 = list1.Next;
                list2 = list2.Next;
            }

            // If not finding an intersection is a valid case then it makes sense to return null here,
            // otherwise if we always expected an intersection, it would make more sense to throw an exception.
            return null;
        }

        private static int GetLength<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            int length = 0;

            while (head != null)
            {
                length++;
                head = head.Next;
            }

            return length;
        }
    }
}
