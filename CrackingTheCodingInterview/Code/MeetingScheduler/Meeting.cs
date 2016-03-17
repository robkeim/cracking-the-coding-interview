using System;
using System.Diagnostics;

namespace Code
{
    [DebuggerDisplay("StartHour = {StartHour}, EndHour = {EndHour}")]
    public class Meeting
    {
        public Meeting(int startHour, int endHour)
        {
            if (startHour < 0 || endHour > 23 || endHour <= startHour)
            {
                throw new ArgumentException("Invalid meeting hours");
            }

            StartHour = startHour;
            EndHour = endHour;
        }

        public int StartHour { get; private set; }

        public int EndHour { get; private set; }
    }
}
