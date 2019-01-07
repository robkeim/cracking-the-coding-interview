using System;

namespace Code
{
    public class Party
    {
        public Party(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; }

        public DateTime End { get; }
    }
}
