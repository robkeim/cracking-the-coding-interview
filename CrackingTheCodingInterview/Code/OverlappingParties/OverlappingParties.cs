using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    public static class OverlappingParties
    {
        // Given a list of parties with a start and end time find the start time when
        // the most number of concurrent parties are happening. If one party starts at
        // the exact same time when another party ends those parties are considered to
        // not be overlapping.

        // Space: O(N)
        // Time: O(N^2)
        public static DateTime FindMostOverlappingParties(IEnumerable<Party> parties)
        {
            if (parties == null)
            {
                throw new ArgumentNullException(nameof(parties));
            }

            if (!parties.Any())
            {
                throw new ArgumentException("There must be at least one party", nameof(parties));
            }

            var changes = new List<Tuple<DateTime, int>>();

            foreach (var party in parties)
            {
                if (party.End <= party.Start)
                {
                    throw new ArgumentOutOfRangeException(nameof(parties), "Party end date must be after the start date");
                }

                changes.Add(new Tuple<DateTime, int>(party.Start, 1));
                changes.Add(new Tuple<DateTime, int>(party.End, 0));
            }

            changes = changes
                .OrderBy(e => e.Item1)
                .ThenBy(e => e.Item2)
                .ToList();

            var result = DateTime.MinValue;
            var maxOverlappingParties = int.MinValue;
            var numOverlappingParties = 0;

            foreach (var change in changes)
            {
                if (change.Item2 == 1)
                {
                    // Party start
                    numOverlappingParties++;
                    if (numOverlappingParties > maxOverlappingParties)
                    {
                        maxOverlappingParties = numOverlappingParties;
                        result = change.Item1;
                    }
                }
                else
                {
                    // Party end
                    numOverlappingParties--;
                }
            }

            return result;
        }
    }
}
