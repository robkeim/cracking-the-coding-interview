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
        private readonly Stack<T> _stack;
        private readonly Stack<T> _tmpStack;
        private int _numItems;

        public SortedStack()
        {
            _stack = new Stack<T>();
            _tmpStack = new Stack<T>();
        }

        // Time: O(N)
        // Space: O(1) -> no additional space besides the items in the stack
        public void Push(T item)
        {
            while (_stack.Count != 0 && item.CompareTo(_stack.Peek()) > 0)
            {
                _tmpStack.Push(_stack.Pop());
            }

            while (_tmpStack.Count != 0 && item.CompareTo(_tmpStack.Peek()) < 0)
            {
                _stack.Push(_tmpStack.Pop());
            }

            _stack.Push(item);

            _numItems++;
        }

        // Time: O(N)
        // Space: O(1) -> no additional space besides the items in the stack
        public T Pop()
        {
            Peek();
            _numItems--;

            return _stack.Pop();
        }

        // Time: O(N)
        // Space: O(1) -> no additional space besides the items in the stack
        public T Peek()
        {
            if (_numItems == 0)
            {
                throw new InvalidOperationException("Stack has no elements");
            }

            while (_tmpStack.Count != 0)
            {
                _stack.Push(_tmpStack.Pop());
            }

            return _stack.Peek();
        }

        // Time: O(1)
        // Space: O(1)
        public bool IsEmpty()
        {
            return _numItems == 0;
        }
    }
}
