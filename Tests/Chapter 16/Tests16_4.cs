using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests16_4
    {
        [TestMethod]
        public void HasWinner_ReturnsFalse_ForEmptyBoard()
        {
            // Arrange
            var board = new int?[3, 3];

            // Act
            var result = Question16_4.HasWinner(board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasWinner_ReturnsTrue_ForHorizontalWin()
        {
            // Arrange
            var board = new int?[3, 3];
            board[0, 0] = 1;
            board[1, 0] = 1;
            board[2, 0] = 1;

            // Act
            var result = Question16_4.HasWinner(board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasWinner_ReturnsTrue_ForVerticalWin()
        {
            // Arrange
            var board = new int?[3, 3];
            board[0, 0] = 1;
            board[0, 1] = 1;
            board[0, 2] = 1;

            // Act
            var result = Question16_4.HasWinner(board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasWinner_ReturnsTrue_ForTopLeftToBottomRightWin()
        {
            // Arrange
            var board = new int?[3, 3];
            board[0, 0] = 1;
            board[1, 1] = 1;
            board[2, 2] = 1;

            // Act
            var result = Question16_4.HasWinner(board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasWinner_ReturnsTrue_ForTopRightToBottomLeftWin()
        {
            // Arrange
            var board = new int?[3, 3];
            board[0, 2] = 1;
            board[1, 1] = 1;
            board[2, 0] = 1;

            // Act
            var result = Question16_4.HasWinner(board);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void HasWinner_ReturnsFalse_WithMultiplePlayersInSameRow()
        {
            // Arrange
            var board = new int?[3, 3];
            board[0, 0] = 1;
            board[0, 1] = 1;
            board[0, 2] = 2;

            // Act
            var result = Question16_4.HasWinner(board);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void HasWinner_ThrowsArgumentInvalidException_WhenBoardIsNull()
        {
            // Act
            void action() => Question16_4.HasWinner(null);

            // Assert
            TestHelpers.AssertExceptionThrown(action, typeof(ArgumentNullException));
        }
    }
}
