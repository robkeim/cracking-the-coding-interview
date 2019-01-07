using System;
using System.Text;

namespace Code
{
    public static class Question5_2
    {
        // 5.2. Binary to String: Given a real number between 0 and 1 (e.g., 0.72) that is
        // passed in as a double, print the binary representation. If the number cannot be
        // represented accurately in binary with at most 32 characters, print "ERROR".

        // Space: O(1)
        // Time: O(1)
        public static string BinaryToString(double number)
        {
            if (number <= 0 || number >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            var result = new StringBuilder();
            result.Append("0.");

            int numCharacters = 0;

            while (number != 0 && numCharacters < 30)
            {
                number *= 2;

                if (number >= 1)
                {
                    result.Append(1);
                    number -= 1;
                }
                else
                {
                    result.Append(0);
                }
            }

            // This condition never is true due to rounding precision in the previous
            // calculations
            if (number != 0)
            {
                return "ERROR";
            }

            return result.ToString();
        }
    }
}
