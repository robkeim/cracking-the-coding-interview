using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Code
{
    // 3.4 Queue via Stacks: Implement a MyQueue class which implements a queue using two stacks.
    [SuppressMessage("Documentation Rules", "SA1649", Justification = "Aligning with question naming convention")]
    [SuppressMessage("Microsoft.Naming", "CA1711", Justification = "Using the name from the question")]
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
