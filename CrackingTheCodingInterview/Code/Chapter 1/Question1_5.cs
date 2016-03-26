using System;

namespace Code
{
    public static class Question1_5
    {
        // 1.5 One Away: There are three types of edits that can be performed on strings: insert a character, remove a character, or replace a character.  Given two strings, write a function to check if they are one dit (or zero edits) away.
        //     EXAMPLE
        //     pale, ple -> true
        //     pales, pale -> true
        //     pale, bale -> true
        //     pale, bake -> false

        // Space: O(1)
        // Time: O(N)
        public static bool IsOneAway(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                throw new ArgumentException("Input must not be null/empty");
            }

            return string.Equals(s1, s2)
                || IsAddOrRemoveCharacter(s1, s2)
                || IsReplaceCharacter(s1, s2);
        }

        private static bool IsAddOrRemoveCharacter(string s1, string s2)
        {
            string longStr;
            string shortStr;

            if (s1.Length > s2.Length)
            {
                longStr = s1;
                shortStr = s2;
            }
            else
            {
                longStr = s2;
                shortStr = s1;
            }

            if (longStr.Length - shortStr.Length != 1)
            {
                return false;
            }

            bool foundMissing = false;
            int shortIndex = 0;
            int longIndex = 0;

            while (shortIndex < shortStr.Length)
            {
                if (shortStr[shortIndex] != longStr[longIndex])
                {
                    if (foundMissing)
                    {
                        return false;
                    }
                    else
                    {
                        foundMissing = true;
                        longIndex++;
                    }
                }
                else
                {
                    shortIndex++;
                    longIndex++;
                }
            }

            return true;
        }

        private static bool IsReplaceCharacter(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            bool foundReplacement = false;

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                {
                    if (foundReplacement)
                    {
                        return false;
                    }
                    else
                    {
                        foundReplacement = true;
                    }
                }
            }

            return true;
        }
    }
}
