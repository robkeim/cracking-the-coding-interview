using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CountingIslandsTests
    {
        [TestMethod]
        public void CountIslands_WithNoIslands_ReturnsZero()
        {
            // Arrange
            var map = new bool[2, 2];

            // Act
            var actual = CountingIslands.CountIslands(map);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void CountIslands_WithNoIslandsRectangularMap_ReturnsZero()
        {
            // Arrange
            var map = new bool[2, 1];

            // Act
            var actual = CountingIslands.CountIslands(map);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void CountIslands_WithOneIsland_ReturnsOne()
        {
            // Arrange
            var map = new bool[2, 2];
            map[0, 0] = true;

            // Act
            var actual = CountingIslands.CountIslands(map);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void CountIslands_WithOneIslandAdjacentSquares_ReturnsOne()
        {
            // Arrange
            var map = new bool[2, 2];
            map[0, 0] = true;
            map[0, 1] = true;

            // Act
            var actual = CountingIslands.CountIslands(map);

            // Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void CountIslands_WithTwoIslands_ReturnsTwo()
        {
            // Arrange
            var map = new bool[3, 3];
            map[0, 0] = true;
            map[2, 2] = true;

            // Act
            var actual = CountingIslands.CountIslands(map);

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void CountIslands_WithTwoIslandsDiagonal_ReturnsTwo()
        {
            // Arrange
            var map = new bool[2, 2];
            map[0, 0] = true;
            map[1, 1] = true;

            // Act
            var actual = CountingIslands.CountIslands(map);

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void CountIslands_WithOneIslandMultipleDirections_ReturnsOne()
        {
            // Arrange
            var map = new bool[3, 3];
            map[0, 0] = true;
            map[0, 1] = true;
            map[0, 2] = true;
            map[1, 0] = true;
            map[2, 0] = true;

            // Act
            var actual = CountingIslands.CountIslands(map);

            // Assert
            Assert.AreEqual(1, actual);
        }
    }
}
