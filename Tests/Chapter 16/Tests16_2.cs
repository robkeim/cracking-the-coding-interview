using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests16_2
    {
        [TestMethod]
        public void WordFrequency_ReturnsFrequency_WithOneWord()
        {
            // Arrange
            var book = new[] { "foo" };

            // Act
            var result = Question16_2.WordFrequency(book, "foo");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WordFrequency_ReturnsFrequency_WithMultipleOccurrences()
        {
            // Arrange
            var book = new[] { "foo", "foo" };

            // Act
            var result = Question16_2.WordFrequency(book, "foo");

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void WordFrequency_ReturnsFrequency_WithTwoWords()
        {
            // Arrange
            var book = new[] { "foo", "bar" };

            // Act
            var result = Question16_2.WordFrequency(book, "foo");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WordFrequency_ReturnsZero_WithNoOccurrences()
        {
            // Arrange
            var book = new[] { "foo" };

            // Act
            var result = Question16_2.WordFrequency(book, "bar");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void WordFrequency_ThrowsArgumentNullException_WhenBookIsNull()
        {
            // Act
            void action() => Question16_2.WordFrequency(null, "foo");

            // Assert
            TestHelpers.AssertExceptionThrown(action, typeof(ArgumentNullException));
        }

        [TestMethod]
        public void WordFrequency_ThrowsArgumentNullException_WhenTargetWordIsNull()
        {
            // Arrange
            var book = new[] { "foo" };

            // Act
            void action() => Question16_2.WordFrequency(book, null);

            // Assert
            TestHelpers.AssertExceptionThrown(action, typeof(ArgumentNullException));
        }

        [TestMethod]
        public void PreprocessBook_ThrowsArgumentNullException_WhenBookIsNull()
        {
            // Act
            void action() => Question16_2.PreprocessBook(null);

            // Assert
            TestHelpers.AssertExceptionThrown(action, typeof(ArgumentNullException));
        }

        [TestMethod]
        public void WordFrequencyPreprocessed_ReturnsFrequency_WithOneWord()
        {
            // Arrange
            var book = new[] { "foo" };
            Question16_2.PreprocessBook(book);

            // Act
            var result = Question16_2.WordFrequencyPreprocessed("foo");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WordFrequencyPreprocessed_ReturnsFrequency_WithMultipleOccurrences()
        {
            // Arrange
            var book = new[] { "foo", "foo" };
            Question16_2.PreprocessBook(book);

            // Act
            var result = Question16_2.WordFrequencyPreprocessed("foo");

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void WordFrequencyPreprocessed_ReturnsFrequency_WithTwoWords()
        {
            // Arrange
            var book = new[] { "foo", "bar" };
            Question16_2.PreprocessBook(book);

            // Act
            var result = Question16_2.WordFrequencyPreprocessed("foo");

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void WordFrequencyPreprocessed_ReturnsZero_WithNoOccurrences()
        {
            // Arrange
            var book = new[] { "foo" };
            Question16_2.PreprocessBook(book);

            // Act
            var result = Question16_2.WordFrequencyPreprocessed("bar");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void WordFrequencyPreprocessed_ThrowsArgumentNullException_WhenTargetWordIsNull()
        {
            // Arrange
            var book = new[] { "foo" };
            Question16_2.PreprocessBook(book);

            // Act
            void action() => Question16_2.WordFrequencyPreprocessed(null);

            // Assert
            TestHelpers.AssertExceptionThrown(action, typeof(ArgumentNullException));
        }
    }
}
