using System;

namespace Code
{
    public static class Question2_5
    {
        // 2.5. Sum Lists: You have two numbers represented by a linked list, where each node contains a single digit.The digits are stored in reverse order, such that the 1's digit is at the head of the list.  Write a function that adds the two numbers and returns the sum as a linked list.
        //      EXAMPLE
        //      Input: (7 -> 1 -> 6) + (5 -> 9 -> 2).  that is, 617 + 295.
        //      Output: 2 -> 1 -> 9.  That is, 912.
        //      FOLLOW UP
        //      Suppose the digits are stored in forward order.Repeat the above problem.
        //      EXAMPLE
        //      Input: (6 -> 1 -> 7) + (2 -> 9 -> 5).  That is 617 + 295.
        //      Output: 9 -> 1 -> 2.  That is, 912.

        // Space: O(N)
        // Time: O(N)
        public static Node<Digit> Add(Node<Digit> num1, Node<Digit> num2)
        {
            if (num1 == null || num2 == null)
            {
                throw new ArgumentNullException("Inputs must not be null");
            }

            Node<Digit> result = null;
            Node<Digit> resultTail = null;
            bool carryOver = false;

            while (num1 != null || num2 != null || carryOver)
            {
                int value = (num1?.Data ?? 0) + (num2?.Data ?? 0) + (carryOver ? 1 : 0);

                if (value >= 10)
                {
                    carryOver = true;
                    value -= 10;
                }
                else
                {
                    carryOver = false;
                }

                if (result == null)
                {
                    result = new Node<Digit>(new Digit(value));
                    resultTail = result;
                }
                else
                {
                    resultTail.Next = new Node<Digit>(new Digit(value));
                    resultTail = resultTail.Next;
                }

                num1 = num1?.Next;
                num2 = num2?.Next;
            }

            return result;
        }

        // Space: O(N)
        // Time: O(N)
        public static Node<Digit> AddNotReversed(Node<Digit> num1, Node<Digit> num2)
        {
            num1 = ReverseList(num1);
            num2 = ReverseList(num2);

            var result = Add(num1, num2);
            return ReverseList(result);
        }

        private static Node<T> ReverseList<T>(Node<T> head)
            where T : IEquatable<T>
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            Node<T> prev = null;
            Node<T> cur = head;

            while (cur != null)
            {
                var tmp = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = tmp;
            }

            return prev;
        }
    }
}
