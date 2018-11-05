using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test4_4
    {
        [TestMethod]
        public void SingleNode_IsBalanced_ReturnsTrue()
        {
            // Arrange
            var root = new BinaryTreeNode<int>(0);

            // Act
            var result = Question4_4.IsBalanced(root);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OneLevelDifference_IsBalanced_ReturnsTrue()
        {
            /*
             *   1
             *  /
             * 0
             */

            // Arrange
            var left = new BinaryTreeNode<int>(0);
            var root = new BinaryTreeNode<int>(1, left, null);

            // Act
            var result = Question4_4.IsBalanced(root);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CompleteTree_IsBalanced_ReturnsTrue()
        {
            /*
             *   2
             *  / \
             * 0   1
             */

            // Arrange
            var left = new BinaryTreeNode<int>(0);
            var right = new BinaryTreeNode<int>(1);
            var root = new BinaryTreeNode<int>(2, left, right);

            // Act
            var result = Question4_4.IsBalanced(root);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UnbalancedTreeAtRoot_IsBalanced_ReturnsFalse()
        {
            /*
             *     2
             *    /
             *   1
             *  /
             * 0
             */

            // Arrange
            var left2 = new BinaryTreeNode<int>(0);
            var left = new BinaryTreeNode<int>(1, left2, null);
            var root = new BinaryTreeNode<int>(2, left, null);

            // Act
            var result = Question4_4.IsBalanced(root);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UnbalancedTreeAtLowerLevel_IsBalanced_ReturnsFalse()
        {
            /*
             *       6
             *      / \
             *     2   5
             *    /     \
             *   1       4
             *  /         \
             * 0           3
             */
            // Arrange
            var left3 = new BinaryTreeNode<int>(0);
            var left2 = new BinaryTreeNode<int>(1, left3, null);
            var left = new BinaryTreeNode<int>(2, left2, null);
            var right3 = new BinaryTreeNode<int>(3);
            var right2 = new BinaryTreeNode<int>(4, null, right3);
            var right = new BinaryTreeNode<int>(5, null, right2);
            var root = new BinaryTreeNode<int>(6, left, right);

            // Act
            var result = Question4_4.IsBalanced(root);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
