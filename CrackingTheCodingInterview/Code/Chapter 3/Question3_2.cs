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

        private readonly T[] _stackValues;
        private readonly T[] _minValues;

        private int _numItems;

        public MinStack()
        {
            _stackValues = new T[MaxSize];
            _minValues = new T[MaxSize];
        }

        // Space: O(1)
        // Time: O(1)
        public T Pop()
        {
            if (_numItems == 0)
            {
                throw new InvalidOperationException("Stack does not contain any elements");
            }

            var result = _stackValues[_numItems - 1];
            _numItems--;

            return result;
        }

        // Space: O(1)
        // Time: O(1)
        public void Push(T item)
        {
            if (_numItems == MaxSize)
            {
                throw new InvalidOperationException("No more space in the stack");
            }

            _stackValues[_numItems] = item;

            var curMin = _numItems == 0
                ? item
                : _minValues[_numItems - 1];

            _minValues[_numItems] = item.CompareTo(curMin) < 0
                ? item
                : curMin;

            _numItems++;
        }

        // Space: O(1)
        // Time: O(1)
        public T Min()
        {
            if (_numItems == 0)
            {
                throw new InvalidOperationException("Stack does not contain any elements");
            }

            return _minValues[_numItems - 1];
        }
    }
}
