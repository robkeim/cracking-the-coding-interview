using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Code
{
    // I originally misread question 3.5 as asking to write a stack that stays sorted as you add elements not sorting an existing stack.
    // I had finished this implementation before I realized my mistake, so I left it here.
    [SuppressMessage("Microsoft.Naming", "CA1711")]
    public class SortedStack<T>
            where T : IComparable<T>
    {
        private readonly Stack<T> stack;
        private readonly Stack<T> tmpStack;
        private int numItems;

        public SortedStack()
        {
            stack = new Stack<T>();
            tmpStack = new Stack<T>();
        }

        // Time: O(N)
        // Space: O(1) -> no additional space besides the items in the stack
        public void Push(T item)
        {
            while (stack.Count != 0 && item.CompareTo(stack.Peek()) > 0)
            {
                tmpStack.Push(stack.Pop());
            }

            while (tmpStack.Count != 0 && item.CompareTo(tmpStack.Peek()) < 0)
            {
                stack.Push(tmpStack.Pop());
            }

            stack.Push(item);

            numItems++;
        }

        // Time: O(N)
        // Space: O(1) -> no additional space besides the items in the stack
        public T Pop()
        {
            Peek();
            numItems--;

            return stack.Pop();
        }

        // Time: O(N)
        // Space: O(1) -> no additional space besides the items in the stack
        public T Peek()
        {
            if (numItems == 0)
            {
                throw new InvalidOperationException("Stack has no elements");
            }

            while (tmpStack.Count != 0)
            {
                stack.Push(tmpStack.Pop());
            }

            return stack.Peek();
        }

        // Time: O(1)
        // Space: O(1)
        public bool IsEmpty()
        {
            return numItems == 0;
        }
    }
}
