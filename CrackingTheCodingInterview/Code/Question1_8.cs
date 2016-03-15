using System;

namespace Code
{
    public static class Question1_8
    {
        // 1.8  Assume you have a method isSubstring which checks if one word is a substring of another. Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring (e.g.,"waterbottle" is a rotation of "erbottlewat").
        public static bool IsRotation(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }

            if (s1.Length != s2.Length)
            {
                return false;
            }

            var doubledS1 = s1 + s1;

            return doubledS1.Contains(s2);
        }
    }
}
