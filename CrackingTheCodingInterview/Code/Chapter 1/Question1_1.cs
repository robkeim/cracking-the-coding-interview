using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public static class Question1_1
    {
        // 1.1 Is Unique: Implement an algorithm to determine if a string has all unique characters.  What if you cannot use additional data structures?

        // Space: O(N)
        // Time: O(N)
        public static bool AreAllCharactersUnique(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            var charactersInString = new HashSet<char>();
            foreach (char c in input)
            {
                if (!charactersInString.Add(c))
                {
                    return false;
                }
            }

            return true;
        }

        // Space: O(1)
        // Time: O(N^2)
        public static bool AreAllCharactersUniqueNoAdditionalMemory(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Space: O(n)
        // Time: O(1)
        public static bool AreAllCharactersUniqueLinQSolution(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            return input.Distinct().ToArray().Length == input.Length;
        }
    }
}
