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
        public static Node<Digit> Add(Node<Digit> firstNumber, Node<Digit> secondNumber)
        {
            if (firstNumber == null)
            {
                throw new ArgumentNullException(nameof(firstNumber));
            }

            if (secondNumber == null)
            {
                throw new ArgumentNullException(nameof(secondNumber));
            }

            Node<Digit> result = null;
            Node<Digit> resultTail = null;
            bool carryOver = false;

            while (firstNumber != null || secondNumber != null || carryOver)
            {
                int value = firstNumber?.Data + secondNumber?.Data + (carryOver ? 1 : 0);

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

                firstNumber = firstNumber?.Next;
                secondNumber = secondNumber?.Next;
            }

            return result;
        }

        // Space: O(N)
        // Time: O(N)
        public static Node<Digit> AddNotReversed(Node<Digit> firstNumber, Node<Digit> secondNumber)
        {
            firstNumber = ReverseList(firstNumber);
            secondNumber = ReverseList(secondNumber);

            var result = Add(firstNumber, secondNumber);
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
