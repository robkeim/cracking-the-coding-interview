using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests16_1
    {
        [TestMethod]
        public void SwapNumbers_ReturnsCorrectValue_ForTwoPositiveNumbers()
        {
            // Arrange
            var num1 = 1;
            var num2 = 2;

            // Act
            Question16_1.SwapNumbers(ref num1, ref num2);

            // Assert
            Assert.AreEqual(2, num1);
            Assert.AreEqual(1, num2);
        }

        [TestMethod]
        public void SwapNumbers_ReturnsCorrectValue_ForNegativeNumber()
        {
            // Arrange
            var num1 = -1;
            var num2 = 2;

            // Act
            Question16_1.SwapNumbers(ref num1, ref num2);

            // Assert
            Assert.AreEqual(2, num1);
            Assert.AreEqual(-1, num2);
        }

        [TestMethod]
        public void SwapNumbers_ReturnsCorrectValue_ForNumbersWithSameValue()
        {
            // Arrange
            var num1 = 1;
            var num2 = 1;

            // Act
            Question16_1.SwapNumbers(ref num1, ref num2);

            // Assert
            Assert.AreEqual(1, num1);
            Assert.AreEqual(1, num2);
        }
    }
}
