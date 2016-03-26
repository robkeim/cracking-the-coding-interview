using System;
using System.Diagnostics.CodeAnalysis;

namespace Code
{
    // 3.2 Stack Min: How would you design a stack which, in addition to push and pop, has a function min which returns the minimum element?
    //     Push, pop, and min should all operate in O(1) time.
    [SuppressMessage("Documentation Rules", "SA1649", Justification = "Aligning with question naming convention")]
    [SuppressMessage("Microsoft.Naming", "CA1711", Justification = "Explicitly not inheriting from stack")]
    public class MinStack<T>
        where T : IComparable<T>
    {
        // NOTE: a better implemention would grow the size dynamically when more space was needed
        private const int MaxSize = 100;

        private readonly T[] stackValues;
        private readonly T[] minValues;

        private int numElements;

        public MinStack()
        {
            stackValues = new T[MaxSize];
            minValues = new T[MaxSize];
        }

        public T Pop()
        {
            if (numElements == 0)
            {
                throw new InvalidOperationException("Stack does not contain any elements");
            }

            var result = stackValues[numElements - 1];
            numElements--;

            return result;
        }

        public void Push(T item)
        {
            if (numElements == MaxSize)
            {
                throw new InvalidOperationException("No more space in the stack");
            }

            stackValues[numElements] = item;

            var curMin = numElements == 0
                ? item
                : minValues[numElements - 1];

            minValues[numElements] = item.CompareTo(curMin) < 0
                ? item
                : curMin;

            numElements++;
        }

        public T Min()
        {
            if (numElements == 0)
            {
                throw new InvalidOperationException("Stack does not contain any elements");
            }

            return minValues[numElements - 1];
        }
    }
}
