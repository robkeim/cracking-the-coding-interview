using System;

namespace Code
{
    public static class Question1_9
    {
        // 1.9  String Rotation: Assume you have a method isSubstring which checks if one word is a substring of another. Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring (e.g.,"waterbottle" is a rotation of "erbottlewat").
        public static bool IsRotation(string string1, string string2)
        {
            if (string.IsNullOrEmpty(string1) || string.IsNullOrEmpty(string2))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }

            if (string1.Length != string2.Length)
            {
                return false;
            }

            var doubledS1 = string1 + string1;

            return doubledS1.Contains(string2);
        }
    }
}
