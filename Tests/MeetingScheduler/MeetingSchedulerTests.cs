using System;
using System.Collections.Generic;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MeetingSchedulerTests
    {
        [TestMethod]
        public void SampleTest()
        {
            // Work day: (8, 17)
            // Person1: (8,10), (10, 12), (15,16)
            // Person2: (11, 14)
            // Result: (14, 15), (16, 17)
            var people = new List<Person>();
            people.Add(CreatePerson(8, 10, 10, 12, 15, 16));
            people.Add(CreatePerson(11, 14));

            var results = MeetingScheduler.FindMeetingTimes(8, 17, people);
            ValidateResults(results, 14, 15, 16, 17);
        }

        private static void ValidateResults(List<Meeting> meetings, params int[] expectedResults)
        {
            if (meetings.Count * 2 != expectedResults.Length)
            {
                Assert.Fail("Unexpected number of meetings");
            }

            for (int i = 0; i < meetings.Count; i += 2)
            {
                Assert.AreEqual(expectedResults[i], meetings[i].StartHour);
                Assert.AreEqual(expectedResults[i + 1], meetings[i].EndHour);
            }
        }

        // Creates a person assuming pairs of meetings (start1, end1, start2, end2...)
        private static Person CreatePerson(params int[] meetingHours)
        {
            if (meetingHours.Length % 2 != 0)
            {
                throw new ArgumentException("Must provide and even number of meeting hours");
            }

            var schedule = new List<Meeting>();

            var count = 0;

            while (count < meetingHours.Length)
            {
                schedule.Add(new Meeting(meetingHours[count], meetingHours[count + 1]));

                count += 2;
            }

            return new Person(schedule);
        }
    }
}
