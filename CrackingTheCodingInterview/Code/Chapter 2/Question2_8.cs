using System;
using System.Collections.Generic;

namespace Code
{
    public static class Question2_8
    {
        // 2.8 Loop Detection: Given a circular linked list, implement an algorithm that returns the node at the beginning of the loop.
        //     DEFINITION
        //     Circular linked list: A(corrupt) linked list in which a node's next pointer points to an earlier node, so as to make a loop in the linked list.
        //     EXAMPLE
        //     Input:  A -> B -> C -> D -> E -> C[the same C as earlier]
        //     Output: C

        // Space: O(N)
        // Time: O(N)
        public static Node<T> FindLoopStart<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            var set = new HashSet<Node<T>>(new ReferenceComprer<Node<T>>());

            while (head != null && set.Add(head))
            {
                head = head.Next;
            }

            return head;
        }

        private class ReferenceComprer<T> : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                return ReferenceEquals(x, y);
            }

            public int GetHashCode(T obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
