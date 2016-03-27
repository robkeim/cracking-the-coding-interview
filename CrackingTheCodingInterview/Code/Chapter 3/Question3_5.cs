using System;
using System.Collections.Generic;

namespace Code
{
    // 3.5 Sort Stack: Write a program to sort a stack such that the smallest items are on the top.  You can use an
    // additional temporary stack, but you may not copy the elements into any other data structure (such as an array).
    // The stack supports the following operations: push, pop, peek, and isEmpty.
    public static class Question3_5
    {
        // Time: O(N)
        // Space: O(1) -> no additional space besides the items in the stack
        public static void SortStack<T>(Stack<T> stack)
            where T : IComparable
        {
            if (stack == null)
            {
                throw new ArgumentNullException(nameof(stack));
            }

            var tmp = new Stack<T>();

            while (stack.Count != 0)
            {
                var item = stack.Pop();

                while (tmp.Count != 0 && item.CompareTo(tmp.Peek()) < 0)
                {
                    stack.Push(tmp.Pop());
                }

                tmp.Push(item);
            }

            while (tmp.Count != 0)
            {
                stack.Push(tmp.Pop());
            }
        }
    }
}
