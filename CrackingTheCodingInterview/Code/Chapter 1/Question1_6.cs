using System;
using System.Text;

namespace Code
{
    public static class Question1_6
    {
        // 1.6 String Compression: Implement a method to perform basic string compression using the counts of repeated characters.  For example, the string aabcccccaaa would become a2b1c5a3.  If the "compressed" string would not become smaller than the original string, your method should return the original string.
        // Space: O(N)
        // Time: O(N)
        public static string Compress(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                throw new ArgumentException("Input cannot be null or empty", nameof(inputString));
            }

            if (inputString.Length == 1)
            {
                return inputString;
            }

            var curChar = inputString[0];
            var curCount = 1;
            var result = new StringBuilder();

            for (int i = 1; i < inputString.Length; i++)
            {
                if (curChar == inputString[i])
                {
                    curCount++;
                }
                else
                {
                    result.Append(curChar);
                    result.Append(curCount);
                    curChar = inputString[i];
                    curCount = 1;
                }
            }

            result.Append(curChar);
            result.Append(curCount);

            var resultString = result.ToString();

            return resultString.Length < inputString.Length
                ? resultString
                : inputString;
        }
    }
}
