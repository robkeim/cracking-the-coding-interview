using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public static class Question1_5
    {
        // 1.5 Implement a method to perform basic string compression using the counts of repeated characters.  For example, the string aabcccccaaa would become a2b1c5a3.  If the "compressed" string would not become smaller than the original string, your method should return the original string.

        // Space: O(N)
        // Time: O(N)
        public static string Compress(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(nameof(str), "Input cannot be null or empty");
            }

            if (str.Length == 1)
            {
                return str;
            }

            var curChar = str[0];
            var curCount = 1;
            var result = new StringBuilder();

            for (int i = 1; i < str.Length; i++)
            {
                if (curChar == str[i])
                {
                    curCount++;
                }
                else
                {
                    result.Append(curChar);
                    result.Append(curCount);
                    curChar = str[i];
                    curCount = 1;
                }
            }

            result.Append(curChar);
            result.Append(curCount);

            var resultString = result.ToString();

            return resultString.Length < str.Length
                ? resultString
                : str;
        }
    }
}
