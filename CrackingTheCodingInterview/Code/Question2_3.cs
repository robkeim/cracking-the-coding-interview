using System;

namespace Code
{
    public static class Question2_3
    {
        // 2.3 Implement an algorithm to delete a node in the middle of a singly linked list, given only access to that node.
        //     EXAMPLE
        //     Input: the node c from the linked list a->b->c->d->e
        //     Result: nothing is returned, but the new linked list looks like a->b->d->e

        // Space: O(1)
        // Time: O(1)
        // NOTE: this algorithm will not work if the element to be removed is the last one in the list
        public static void RemoveNode<T>(Node<T> node) where T : IEquatable<T>
        {
            if (node == null || node.Next == null)
            {
                throw new ArgumentException("Node cannot be null/last element in list");
            }

            node.Data = node.Next.Data;
            node.Next = node.Next.Next;
        }
    }
}
