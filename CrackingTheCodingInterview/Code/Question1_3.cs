using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public class Question1_3
    {
        // 1.3 Given two strings, write a method to decide if one is a permutation of the other

        // Space: O(N)
        // Time: O(N log N)

        public static bool AreStringsPermutation(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                throw new ArgumentException("Input strings cannot be null or empty");
            }

            if (str1.Length != str2.Length)
            {
                return false;
            }

            var sortedStr1 = string.Concat(str1.OrderBy(c => c));
            var sortedStr2 = string.Concat(str2.OrderBy(c => c));

            return sortedStr1.Equals(sortedStr2);
        }

        // Space: O(N)
        // Time: O(N)
        public static bool AreStringsPermutationNoSort(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
            {
                throw new ArgumentException("Input strings cannot be null or empty");
            }

            if (str1.Length != str2.Length)
            {
                return false;
            }

            var allChars = new Dictionary<char, int>();

            for (int i = 0; i < str1.Length; i++)
            {
                var c = str1[i];
                if (allChars.ContainsKey(c))
                {
                    allChars[c]++;
                }
                else
                {
                    allChars[c] = 1;
                }
            }

            for (int i = 0; i < str2.Length; i++)
            {
                var c = str2[i];
                int occurences = 0;
                if (!allChars.ContainsKey(c))
                {
                    return false;
                }
                else if (occurences == 1)
                {
                    allChars.Remove(c);
                }
                else
                {
                    allChars[c]--;
                }
            }

            return true;
        }
    }
}
