using System;

namespace Code
{
    // This is an implementation of the Rabin-Karp algorithm which can determine if a string is a substring of another in linear time
    // with respect to the larger string. Details of the algorithm can be found here:
    // https://en.wikipedia.org/wiki/Rabin%E2%80%93Karp_algorithm

    // Space: O(1)
    // Time: O(n) where n is the length of the larger string
    public static class SubstringSearch
    {
        public static bool IsSubstring(string toMatch, string toTest)
        {
            if (string.IsNullOrEmpty(toMatch))
            {
                throw new ArgumentException("Input cannot be null/empty", nameof(toMatch));
            }

            if (string.IsNullOrEmpty(toTest))
            {
                throw new ArgumentException("Input cannot be null/empty", nameof(toTest));
            }

            // Short circut to save calculation in the case it's impossible to match
            if (toTest.Length < toMatch.Length)
            {
                return false;
            }

            var hash = 0;

            foreach (var c in toMatch)
            {
                hash ^= c;
            }

            var rollingHash = 0;

            for (int i = 0; i < toTest.Length; i++)
            {
                if (i >= toMatch.Length)
                {
                    rollingHash ^= toTest[i - toMatch.Length];
                }

                rollingHash ^= toTest[i];

                if (hash == rollingHash
                    && i >= toMatch.Length - 1
                    && toTest.Substring(i - toMatch.Length + 1, toMatch.Length) == toMatch)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
