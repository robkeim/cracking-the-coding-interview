using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
    // This class computes the nth most occurring word(s) in a word document. It's been optimized to query multiple times over the same data
    // set. In the case where you're only interested in querying once there would be no reason to build the final dictionary and store it.
    //
    // The complexity of this algorithm is:
    // Time: O(w) + O(uw log uw) where w is the number of words and uw is the number of unique words
    // Space: O(uw) where uw is the number of unique words
    // I've separated the time complexity here because while the n log n sort of the unique words dominates the linear search through all of
    // the words in the worst case, in practical cases where processing large amounts of text in a given language (ex: a book) there are going
    // to be many repeated words and the ratio of the number of unique words to the number of words is going to grow logarithmically.
    public class WordFrequencies
    {
        private readonly IReadOnlyDictionary<int, List<string>> nthMostDictionary;

        public WordFrequencies(IEnumerable<string> words)
        {
            if (words == null)
            {
                throw new ArgumentNullException(nameof(words));
            }

            var frequencies = BuildFrequencyDictionary(words);
            nthMostDictionary = BuildNthMostDictionary(frequencies);
        }

        // There are at least two different ways that could be considered valid orderings here for the following sample case:
        // A exists 2 times
        // B exists 2 times
        // C exists 1 time
        //
        // 1. Return a monotonically increasing list
        //      n = 1 -> { A, B }
        //      n = 2 -> { C }
        //
        // 2. "Olympic style" ordering
        //      n = 1 -> { A, B }
        //      n = 3 -> { C }
        //
        // There is also the choice of zero or one based indexing. For this problem I've gone with one based "Olympic style" ordering
        // as it seemed to be more fun and challenging to implement
        public List<string> GetNthMostOccurring(int nth)
        {
            if (nth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nth));
            }

            List<string> result;

            if (!nthMostDictionary.TryGetValue(nth, out result))
            {
                result = null;
            }

            return result;
        }

        private static Dictionary<string, int> BuildFrequencyDictionary(IEnumerable<string> words)
        {
            var frequencies = new Dictionary<string, int>();

            foreach (var word in words)
            {
                int frequency;

                if (!frequencies.TryGetValue(word, out frequency))
                {
                    frequency = 0;
                }

                frequencies[word] = frequency + 1;
            }

            return frequencies;
        }

        private static IReadOnlyDictionary<int, List<string>> BuildNthMostDictionary(Dictionary<string, int> frequencyDictionary)
        {
            var results = new Dictionary<int, List<string>>();

            foreach (var frequency in frequencyDictionary)
            {
                List<string> values;

                if (!results.TryGetValue(frequency.Value, out values))
                {
                    values = new List<string>();
                    results[frequency.Value] = values;
                }

                values.Add(frequency.Key);
            }

            // Use a ConcurrentDictionary here to ensure thread safety for reads later on
            var finalDictionary = new ConcurrentDictionary<int, List<string>>();

            int index = 1;

            foreach (var values in results.OrderByDescending(kv => kv.Key))
            {
                // No need to check the return value as the adds will always be successful since the algorithm ensures uniqueness at this point
                finalDictionary.TryAdd(index, values.Value.OrderBy(v => v).ToList());
                index += values.Value.Count;
            }

            return finalDictionary;
        }
    }
}
