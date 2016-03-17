using System.Collections.Generic;

namespace Code
{
    public class Person
    {
        public Person(List<Meeting> schedule)
        {
            Schedule = schedule;
        }

        public List<Meeting> Schedule { get; private set; }
    }
}
