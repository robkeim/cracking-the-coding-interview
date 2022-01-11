using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test1_1
    {
        [TestMethod]
        public void ImplementationOne_NoDuplicates_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = "abc";

            // Act
            var actual = Question1_1.AreAllCharactersUnique(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationTwo_NoDuplicates_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = "abc";

            // Act
            var actual = Question1_1.AreAllCharactersUniqueNoAdditionalMemory(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationThree_NoDuplicates_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = "abc";

            // Act
            var actual = Question1_1.AreAllCharactersUniqueLinQSolution(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationOne_Duplicates_ReturnsFalse()
        {
            // Arrange
            const bool expected = false;
            const string input = "aba";

            // Act
            var actual = Question1_1.AreAllCharactersUnique(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationTwo_Duplicates_ReturnsFalse()
        {
            // Arrange
            const bool expected = false;
            const string input = "aba";

            // Act
            var actual = Question1_1.AreAllCharactersUniqueNoAdditionalMemory(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationThree_Duplicates_ReturnsFalse()
        {
            // Arrange
            const bool expected = false;
            const string input = "aba";

            // Act
            var actual = Question1_1.AreAllCharactersUniqueLinQSolution(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationOne_CasingDifference_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = "Aa";

            // Act
            var actual = Question1_1.AreAllCharactersUnique(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationTwo_CasingDifference_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = "Aa";

            // Act
            var actual = Question1_1.AreAllCharactersUniqueNoAdditionalMemory(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationThree_CasingDifference_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = "Aa";

            // Act
            var actual = Question1_1.AreAllCharactersUniqueLinQSolution(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationOne_NullString_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = null;

            // Act
            var actual = Question1_1.AreAllCharactersUnique(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationTwo_NullString_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = null;

            // Act
            var actual = Question1_1.AreAllCharactersUniqueNoAdditionalMemory(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationThree_NullString_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            const string input = null;

            // Act
            var actual = Question1_1.AreAllCharactersUniqueLinQSolution(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationOne_EmptyString_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            var input = string.Empty;

            // Act
            var actual = Question1_1.AreAllCharactersUnique(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationTwo_EmptyString_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            var input = string.Empty;

            // Act
            var actual = Question1_1.AreAllCharactersUniqueNoAdditionalMemory(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplementationThree_EmptyString_ReturnsTrue()
        {
            // Arrange
            const bool expected = true;
            var input = string.Empty;

            // Act
            var actual = Question1_1.AreAllCharactersUniqueLinQSolution(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
