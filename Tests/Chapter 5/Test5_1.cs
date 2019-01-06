using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test5_1
    {
        [TestMethod]
        public void InsertBits_ReturnsCorrectValue_ForSampleInput()
        {
            // Arrange
            var n = BitHelpers.FromBinaryString("10000000000");
            var m = BitHelpers.FromBinaryString("10011");
            var i = 2;
            var j = 6;
            var expected = BitHelpers.FromBinaryString("10001001100");

            // Act
            var actual = Question5_1.Insertion(n, m, i, j);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
