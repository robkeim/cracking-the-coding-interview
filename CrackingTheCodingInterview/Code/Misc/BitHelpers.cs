using System;

namespace Code
{
    public static class BitHelpers
    {
        public static string ToBinaryString(int value)
        {
            return Convert.ToString(value, 2);
        }

        public static int FromBinaryString(string value)
        {
            return Convert.ToInt32(value, 2);
        }
    }
}
