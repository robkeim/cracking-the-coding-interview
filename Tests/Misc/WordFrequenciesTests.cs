using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class WordFrequenciesTests
    {
        [TestMethod]
        public void SingleWordTest()
        {
            // Arrange
            var words = StringList("a");
            var wordFrequencies = new WordFrequencies(words);
            var expected = StringList("a");
            var numToFind = 1;

            // Act
            var actual = wordFrequencies.GetNthMostOccurring(numToFind);

            // Assert
            AssertListsAreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleWordWithMultipleOccurrencesTest()
        {
            // Arrange
            var words = StringList("a", "a");
            var wordFrequencies = new WordFrequencies(words);
            var expected = StringList("a");
            var numToFind = 1;

            // Act
            var actual = wordFrequencies.GetNthMostOccurring(numToFind);

            // Assert
            AssertListsAreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoWordsMostOccurringTest()
        {
            // Arrange
            var words = StringList("a", "a", "b");
            var wordFrequencies = new WordFrequencies(words);
            var expected = StringList("a");
            var numToFind = 1;

            // Act
            var actual = wordFrequencies.GetNthMostOccurring(numToFind);

            // Assert
            AssertListsAreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoWordsSecondMostOccurringTest()
        {
            // Arrange
            var words = StringList("a", "a", "b");
            var wordFrequencies = new WordFrequencies(words);
            var expected = StringList("b");
            var numToFind = 2;

            // Act
            var actual = wordFrequencies.GetNthMostOccurring(numToFind);

            // Assert
            AssertListsAreEqual(expected, actual);
        }

        [TestMethod]
        public void TwoWordsSameOccurrencesAreSortedTest()
        {
            // Arrange
            var words = StringList("a", "a", "b", "b");
            var wordFrequencies = new WordFrequencies(words);
            var expected = StringList("a", "b");
            var numToFind = 1;

            // Act
            var actual = wordFrequencies.GetNthMostOccurring(numToFind);

            // Assert
            AssertListsAreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderingSkipsValuesTest()
        {
            // Arrange
            var words = StringList("a", "a", "b", "b", "c");
            var wordFrequencies = new WordFrequencies(words);
            var expected = StringList("c");
            var numToFind = 3;

            // Act
            var actual = wordFrequencies.GetNthMostOccurring(numToFind);

            // Assert
            AssertListsAreEqual(expected, actual);
        }

        [TestMethod]
        public void TooLargeFrequencyReturnsNothingTest()
        {
            // Arrange
            var words = StringList("a");
            var wordFrequencies = new WordFrequencies(words);
            List<string> expected = null;
            var numToFind = 2;

            // Act
            var actual = wordFrequencies.GetNthMostOccurring(numToFind);

            // Assert
            AssertListsAreEqual(expected, actual);
        }

        [TestMethod]
        public void InBetweenFrequenciesReturnsNothingTest()
        {
            // Arrange
            var words = StringList("a", "a", "b", "b", "c");
            var wordFrequencies = new WordFrequencies(words);
            List<string> expected = null;
            var numToFind = 2;

            // Act
            var actual = wordFrequencies.GetNthMostOccurring(numToFind);

            // Assert
            AssertListsAreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [SuppressMessage("Microsoft.Usage", "CA1806")]
        public void NullWordsThrowsExceptionTest()
        {
            // Act
            new WordFrequencies(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InvalidNThrowsExceptionTest()
        {
            // Arrange
            var words = StringList("a");
            var wordFrequencies = new WordFrequencies(words);
            var numToFind = 0;

            // Act
            wordFrequencies.GetNthMostOccurring(numToFind);
        }

        private static List<string> StringList(params string[] values)
        {
            return values.ToList();
        }

        private static void AssertListsAreEqual(List<string> expected, List<string> actual)
        {
            if (expected == null && actual == null)
            {
                return;
            }

            Assert.IsTrue(expected != null && actual != null);
            Assert.IsTrue(expected.Count == actual.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
