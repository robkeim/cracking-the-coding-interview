using System;
using System.Collections.Generic;

namespace Code
{
    // You have n people and each has meetings booked in their calendars. The goal is to determine when all n people can meet. Assume the question is for a limited interval, like the work day.  Write unit tests for your implementation.

    // Work day: (8, 17)
    // Person1: (8,10), (10, 12), (15,16)
    // Person2: (11, 14)
    // Result: (14, 15), (16, 17)
    public static class MeetingScheduler
    {
        public static List<Meeting> FindMeetingTimes(int workStartHour, int workEndHour, List<Person> people)
        {
            if (workStartHour < 0 || workEndHour > 23 || workEndHour <= workStartHour)
            {
                throw new ArgumentException("Invalid meeting hours");
            }

            if (people == null || people.Count == 0)
            {
                throw new ArgumentException(nameof(people), "No people for this meeting");
            }

            List<Meeting> results = new List<Meeting>();

            // The space of this array could be optimized
            var isBooked = new bool[24];

            foreach (var person in people)
            {
                foreach (var meeting in person.Schedule)
                {
                    for (int i = meeting.StartHour; i < meeting.EndHour; i++)
                    {
                        isBooked[i] = true;
                    }
                }
            }

            var meetingStartHour = workStartHour;

            while (meetingStartHour < workEndHour)
            {
                if (!isBooked[meetingStartHour])
                {
                    var meetingEndHour = meetingStartHour + 1;

                    while (meetingEndHour < workEndHour && !isBooked[meetingEndHour])
                    {
                        meetingEndHour++;
                    }

                    results.Add(new Meeting(meetingStartHour, meetingEndHour));

                    meetingStartHour = meetingEndHour;
                }
                else
                {
                    meetingStartHour++;
                }
            }

            return results;
        }
    }
}
