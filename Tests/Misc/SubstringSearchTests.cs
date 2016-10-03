using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SubstringSearchTests
    {
        [TestMethod]
        public void BasicTest()
        {
            // Arrange
            var toMatch = "abc";
            var toSearch = "_abc_";
            var expected = true;

            // Act
            var actual = SubstringSearch.IsSubstring(toMatch, toSearch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StartsWithMatchTest()
        {
            // Arrange
            var toMatch = "abc";
            var toSearch = "abc_";
            var expected = true;

            // Act
            var actual = SubstringSearch.IsSubstring(toMatch, toSearch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EndsWithMatchTest()
        {
            // Arrange
            var toMatch = "abc";
            var toSearch = "_abc";
            var expected = true;

            // Act
            var actual = SubstringSearch.IsSubstring(toMatch, toSearch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MultipleMatchesTest()
        {
            // Arrange
            var toMatch = "abc";
            var toSearch = "abcabc";
            var expected = true;

            // Act
            var actual = SubstringSearch.IsSubstring(toMatch, toSearch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoMatchForInvertedStringTest()
        {
            // Arrange
            var toMatch = "abc";
            var toSearch = "cba";
            var expected = false;

            // Act
            var actual = SubstringSearch.IsSubstring(toMatch, toSearch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoMatchForNonadjacentStringTest()
        {
            // Arrange
            var toMatch = "abc";
            var toSearch = "a_b_c";
            var expected = false;

            // Act
            var actual = SubstringSearch.IsSubstring(toMatch, toSearch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NoMatchForDifferentCasingTest()
        {
            // Arrange
            var toMatch = "abc";
            var toSearch = "ABC";
            var expected = false;

            // Act
            var actual = SubstringSearch.IsSubstring(toMatch, toSearch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionForNullFirstArgumentTest()
        {
            // Arrange
            string toMatch = null;
            var toSearch = "abc";

            // Act
            SubstringSearch.IsSubstring(toMatch, toSearch);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionForNullSecondArgumentTest()
        {
            // Arrange
            var toMatch = "abc";
            string toSearch = null;

            // Act
            SubstringSearch.IsSubstring(toMatch, toSearch);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionForEmptyStringFirstArgumentTest()
        {
            // Arrange
            var toMatch = string.Empty;
            var toSearch = "abc";

            // Act
            SubstringSearch.IsSubstring(toMatch, toSearch);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionForEmptyStringSecondArgumentTest()
        {
            // Arrange
            var toMatch = "abc";
            var toSearch = string.Empty;

            // Act
            SubstringSearch.IsSubstring(toMatch, toSearch);
        }
    }
}
