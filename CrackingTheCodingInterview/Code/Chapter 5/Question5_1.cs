using System.Diagnostics.CodeAnalysis;

namespace Code
{
    public static class Question5_1
    {
        // 5.1. Insertion: You are given two 32-bit numbers, N and M, and two bit positions, i and j.
        // Write a method to insert M into N such that M starts at bit j and ends at bit i. You can
        // assume that the bits j through i have enough space to fit all of M. That is, if M = 10011,
        // you can assume that there are at least 5 bits between j and i. You would not, for example,
        // have j = 3 and i = 2, because M coudl nto fully fit between bit 3 and bit 2.
        // EXAMPLE
        // Input: N = 10000000000, M = 10011, i = 2, j = 6
        // Output: N = 10001001100

        // Space: O(1)
        // Time: O(1)
        [SuppressMessage("Microsoft.Naming", "CA1704")]
        public static int Insertion(int n, int m, int i, int j)
        {
            // Create mask to remove bits i through j in N
            var left = ~0 << j;
            var right = (1 << i) - 1;
            var mask = left | right;

            // Remove bits in N
            n &= mask;

            // Align bits in M
            m <<= i;

            // Add bits from M into N
            return m | n;
        }
    }
}
