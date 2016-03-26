using System;
using System.Collections.Generic;

namespace Code
{
    public static class Question1_4
    {
        // 1.4 Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.  A palindrome is a word or phrase that is the same forwards and backwards.A permutation is a rearrangement of letters.The palindrome does not need to be limited to just dictionary words.
        //     EXAMPLE
        //     Input: Tact Coa
        //     Output: True (permutations: "taco cat", "atco cta", etc.)

        // Space: O(N) (where N is the number of unique characters in the string, not the length of the string)
        // Time: O(N)
        public static bool IsPalindromePermutation(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null/empty", nameof(input));
            }

            var occurances = new Dictionary<char, bool>();

            foreach (var c in input)
            {
                bool value;
                occurances.TryGetValue(c, out value);

                occurances[c] = !value;
            }

            bool hasOdd = false;
            foreach (var key in occurances.Keys)
            {
                if (occurances[key])
                {
                    if (hasOdd)
                    {
                        return false;
                    }
                    else
                    {
                        hasOdd = true;
                    }
                }
            }

            return true;
        }

        // Space: O(1)
        // Time: O(N log N)
        public static bool IsPalindromePermutationNoAdditionalSpace(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input cannot be null/empty", nameof(input));
            }

            var inputArray = input.ToCharArray();

            Array.Sort(inputArray);
            
            char prevChar = inputArray[0];
            var count = 0;
            bool hasOdd = false;

            foreach (var c in inputArray)
            {
                if (c != prevChar)
                {
                    if (count % 2 == 1)
                    {
                        if (hasOdd)
                        {
                            return false;
                        }
                        else
                        {
                            hasOdd = true;
                        }
                    }

                    count = 1;
                    prevChar = c;
                }
                else
                {
                    count++;
                }
            }

            if (hasOdd && count % 2 == 1)
            {
                return false;
            }

            return true;
        }
    }
}
