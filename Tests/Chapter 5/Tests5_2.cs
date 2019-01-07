using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests5_2
    {
        [TestMethod]
        public void BinaryToString_ReturnsCorrectValue_ForFiveTenths()
        {
            // Arrange
            var number = 0.5;
            var expected = "0.1";

            // Act
            var actual = Question5_2.BinaryToString(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BinaryToString_ReturnsCorrectValue_ForTwentyFiveHundreds()
        {
            // Arrange
            var number = 0.25;
            var expected = "0.01";

            // Act
            var actual = Question5_2.BinaryToString(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
