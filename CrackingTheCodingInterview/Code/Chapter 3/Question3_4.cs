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
        private readonly Stack<T> stackStack;
        private readonly Stack<T> queueStack;
        private bool isQueue;
        private int numItems;

        public MyQueue()
        {
            stackStack = new Stack<T>();
            queueStack = new Stack<T>();
        }

        // Space: 0(1)
        // Time: O(N) when the previous operation was a remove
        public void Add(T item)
        {
            if (isQueue)
            {
                isQueue = false;
                while (queueStack.Count != 0)
                {
                    stackStack.Push(queueStack.Pop());
                }

                stackStack.Push(item);
            }
            else
            {
                stackStack.Push(item);
            }

            numItems++;
        }

        // Space: O(1)
        // Time: O(N) when the previous operation was an add
        public T Remove()
        {
            if (numItems == 0)
            {
                throw new InvalidOperationException("No items in the queue");
            }

            numItems--;

            if (isQueue)
            {
                return queueStack.Pop();
            }
            else
            {
                isQueue = true;
                while (stackStack.Count != 0)
                {
                    queueStack.Push(stackStack.Pop());
                }

                return queueStack.Pop();
            }
        }
    }
}
