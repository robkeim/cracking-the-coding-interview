using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Code
{
    // 3.3 Stack of Plates: Imagine a (literal) stack of plates.  If the stack gets too high, it might topple.  Therefore, in real life,
    // we would likely start a new stack when the previous stack exceeds some threshold.  Implement a data structure SetOfStacks that mimics
    // this.  SetOfStacks should be composed of several stacks and should create a new stack once the previous one exceeds capacity.
    // SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack (that is, pop() should return the same values as
    // it would if there were just a single stack).
    //    FOLLOW UP
    //    Implement a function popAt(int index) which performans a pop operation on a specific sub-stack.
    [SuppressMessage("Documentation Rules", "SA1649")]
    public class SetOfStacks<T>
    {
        // Small value for testing purposes
        private const int MaxSizePerStack = 2;

        private readonly List<T[]> setOfStacks;
        private int numItems;

        public SetOfStacks()
        {
            setOfStacks = new List<T[]>();
        }

        public void Push(T item)
        {
            if (numItems % MaxSizePerStack == 0)
            {
                // have to create a new stack
                setOfStacks.Add(new T[MaxSizePerStack]);
            }

            var stackNumber = numItems / MaxSizePerStack;
            var itemNumber = numItems % MaxSizePerStack;

            setOfStacks[stackNumber][itemNumber] = item;

            numItems++;
        }

        public T Pop()
        {
            if (numItems == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            numItems--;
            var stackNumber = numItems / MaxSizePerStack;
            var itemNumber = numItems % MaxSizePerStack;

            var result = setOfStacks[stackNumber][itemNumber];

            if (itemNumber == 0)
            {
                setOfStacks.RemoveAt(stackNumber);
            }

            return result;
        }
    }
}
