using System;

namespace Code
{
    public static class Question1_4
    {
        // 1.4 Write a method to replace all spaces in a string with '%20'.  You may assume that the string has sufficient space at the end of the string to hold the additional characters, and that you are given the "true" length of the string. (Note: if implementing in java, please use a character array so that you can perform this operation in place.)

        // EXAMPLE
        // Input:  "Mr John Smith    "
        // Output: "Mr%20John%20Smith"

        // Space: O(1)
        // Time: O(N)
        public static void ReplaceSpaces(char[] str, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Value cannot be negative");
            }

            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Value cannot be null");
            }

            int numSpaces = 0;

            for (int i = 0; i < length; i++)
            {
                if (str[i] == ' ')
                {
                    numSpaces++;
                }
            }

            int offset = 2 * numSpaces;

            for (int i = length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[i + offset] = '0';
                    str[i + offset - 1] = '2';
                    str[i + offset - 2] = '%';
                    offset -= 2;
                }
                else
                {
                    str[i + offset] = str[i];
                }
            }
        }
    }
}
