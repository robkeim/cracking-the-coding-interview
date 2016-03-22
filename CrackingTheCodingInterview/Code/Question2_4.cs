using System;

namespace Code
{
    public static class Question2_4
    {
        // 2.4 Partition: Write code to parition a linked list around a value x, such that all nodes less than x come before all nodes greater than or equal to x.

        // Space: O(1)
        // Time: O(N)
        // This solution is stable meaning that items less than and greater than/equal to x keep their relative order
        public static Node<T> PartitionList<T>(Node<T> head, T x) where T : IEquatable<T>, IComparable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            Node<T> smallerHead = null;
            Node<T> smallerLast = null;
            Node<T> biggerHead = null;
            Node<T> biggerLast = null;

            while (head != null)
            {
                var nodeToAdd = new Node<T>(head.Data);

                if (head.Data.CompareTo(x) < 0)
                {
                    if (smallerLast == null)
                    {
                        smallerHead = nodeToAdd;
                        smallerLast = nodeToAdd;
                    }
                    else
                    {
                        smallerLast.Next = nodeToAdd;
                        smallerLast = nodeToAdd;
                    }
                }
                else
                {
                    if (biggerLast == null)
                    {
                        biggerHead = nodeToAdd;
                        biggerLast = nodeToAdd;
                    }
                    else
                    {
                        biggerLast.Next = nodeToAdd;
                        biggerLast = nodeToAdd;
                    }
                }

                head = head.Next;
            }

            if (smallerHead == null)
            {
                return biggerHead;
            }
            else
            {
                smallerLast.Next = biggerHead;
                return smallerHead;
            }
        }
    }
}
