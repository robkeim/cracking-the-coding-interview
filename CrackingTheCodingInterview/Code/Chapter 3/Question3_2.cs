using System;
using System.Diagnostics.CodeAnalysis;

namespace Code
{
    // 3.2 Stack Min: How would you design a stack which, in addition to push and pop, has a function min which returns the minimum element?
    //     Push, pop, and min should all operate in O(1) time.
    [SuppressMessage("Documentation Rules", "SA1649")]
    [SuppressMessage("Microsoft.Naming", "CA1711")]
    public class MinStack<T>
        where T : IComparable<T>
    {
        // NOTE: a better implemention would grow the size dynamically when more space was needed
        private const int MaxSize = 100;

        private readonly T[] stackValues;
        private readonly T[] minValues;

        private int numItems;

        public MinStack()
        {
            stackValues = new T[MaxSize];
            minValues = new T[MaxSize];
        }

        public T Pop()
        {
            if (numItems == 0)
            {
                throw new InvalidOperationException("Stack does not contain any elements");
            }

            var result = stackValues[numItems - 1];
            numItems--;

            return result;
        }

        public void Push(T item)
        {
            if (numItems == MaxSize)
            {
                throw new InvalidOperationException("No more space in the stack");
            }

            stackValues[numItems] = item;

            var curMin = numItems == 0
                ? item
                : minValues[numItems - 1];

            minValues[numItems] = item.CompareTo(curMin) < 0
                ? item
                : curMin;

            numItems++;
        }

        public T Min()
        {
            if (numItems == 0)
            {
                throw new InvalidOperationException("Stack does not contain any elements");
            }

            return minValues[numItems - 1];
        }
    }
}
