using System;
using System.Diagnostics;

namespace Code
{
    [DebuggerDisplay("Value = {value}")]
    public class Digit : IEquatable<Digit>
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

        public static implicit operator int(Digit digit)
        {
            return digit?.value ?? 0;
        }

        public static int ToInt(Digit digit)
        {
            return digit;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Digit);
        }

        public override int GetHashCode()
        {
            return value;
        }

        public bool Equals(Digit other)
        {
            return other != null && value == other.value;
        }
    }
}
