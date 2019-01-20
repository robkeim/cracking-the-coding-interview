using System;
using System.Diagnostics;

namespace Code
{
    [DebuggerDisplay("Value = {value}")]
    public class Digit : IEquatable<Digit>
    {
        private readonly int _value;

        public Digit(int value)
        {
            if (value < 0 || value > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 9 inclusive");
            }

            _value = value;
        }

        public static implicit operator int(Digit digit)
        {
            return digit?._value ?? 0;
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
            return _value;
        }

        public bool Equals(Digit other)
        {
            return other != null && _value == other._value;
        }
    }
}
