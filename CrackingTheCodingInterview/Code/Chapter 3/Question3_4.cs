using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Code
{
    // 3.4 Queue via Stacks: Implement a MyQueue class which implements a queue using two stacks.
    [SuppressMessage("Documentation Rules", "SA1649")]
    [SuppressMessage("Microsoft.Naming", "CA1711")]
    public class MyQueue<T>
    {
        private readonly Stack<T> _stackStack;
        private readonly Stack<T> _queueStack;
        private bool _isQueue;
        private int _numItems;

        public MyQueue()
        {
            _stackStack = new Stack<T>();
            _queueStack = new Stack<T>();
        }

        // Space: 0(1)
        // Time: O(N) when the previous operation was a remove
        public void Add(T item)
        {
            if (_isQueue)
            {
                _isQueue = false;
                while (_queueStack.Count != 0)
                {
                    _stackStack.Push(_queueStack.Pop());
                }

                _stackStack.Push(item);
            }
            else
            {
                _stackStack.Push(item);
            }

            _numItems++;
        }

        // Space: O(1)
        // Time: O(N) when the previous operation was an add
        public T Remove()
        {
            if (_numItems == 0)
            {
                throw new InvalidOperationException("No items in the queue");
            }

            _numItems--;

            if (_isQueue)
            {
                return _queueStack.Pop();
            }
            else
            {
                _isQueue = true;
                while (_stackStack.Count != 0)
                {
                    _queueStack.Push(_stackStack.Pop());
                }

                return _queueStack.Pop();
            }
        }
    }
}
