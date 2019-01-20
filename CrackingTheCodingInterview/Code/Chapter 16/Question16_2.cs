using System;
using System.Collections.Generic;

namespace Code
{
    public static class Question16_2
    {
        private static Dictionary<string, int> _words;

        // 16.2 Word Frequencies: Design a method to find the frequency of occurances of any
        // given word in a book. What if we were running this algorithm multiple times?

        // Space: O(1)
        // Time: O(N)
        public static int WordFrequency(IEnumerable<string> book, string targetWord)
        {
            book = book ?? throw new ArgumentNullException(nameof(book));
            targetWord = targetWord ?? throw new ArgumentNullException(nameof(targetWord));

            var result = 0;

            foreach (var word in book)
            {
                // This treats different cases as different words
                if (word == targetWord)
                {
                    result++;
                }
            }

            return result;
        }

        // Space: O(UW) where UW is the number of unique words
        // Time: O(W) where W is the number of words
        public static void PreprocessBook(IEnumerable<string> book)
        {
            book = book ?? throw new ArgumentNullException(nameof(book));

            _words = new Dictionary<string, int>();

            foreach (var word in book)
            {
                // Thsi treats different cases as different words
                if (!_words.ContainsKey(word))
                {
                    _words[word] = 0;
                }

                _words[word]++;
            }
        }

        // This implemention does not support concurrency because of the Dictionary that isn't concurrent and is static
        // Space: O(1)
        // Time: O(1)
        public static int WordFrequencyPreprocessed(string word)
        {
            word = word ?? throw new ArgumentNullException(nameof(word));
            _words = _words ?? throw new InvalidOperationException("The preprocess book method must be called first");

            if (_words.ContainsKey(word))
            {
                return _words[word];
            }

            return 0;
        }
    }
}
