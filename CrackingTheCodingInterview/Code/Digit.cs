using System;

namespace Code
{
    public class Digit
    {
        private readonly int value;

        public Digit(int value)
        {
            if (value < 0 || value > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 9 inclusive");
            }

            this.value = value;
        }

        public static implicit operator int(Digit d)
        {
            return d.value;
        }
    }
}
