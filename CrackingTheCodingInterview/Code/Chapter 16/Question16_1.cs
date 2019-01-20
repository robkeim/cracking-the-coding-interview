using System.Diagnostics.CodeAnalysis;

namespace Code
{
    public static class Question16_1
    {
        // 16.1 Number Swapper: Write a function to swap a number in place (that is, without
        // temporary variables).

        // Space: O(1)
        // Time: O(1)
        [SuppressMessage("Microsoft.Design", "CA1045")]
        public static void SwapNumbers(ref int first, ref int second)
        {
            // first = first ^ second
            first ^= second;

            // second = second ^ first
            //        = second ^ (first ^ second)
            //        = first
            second ^= first;

            // first = first ^ second
            //       = (first ^ second) ^ (first)
            //       = second
            first ^= second;
        }
    }
}
