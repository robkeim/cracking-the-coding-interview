using System;
using System.Linq;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test4_2
    {
        [TestMethod]
        public void BasicTest()
        {
            // This test is based on the internal implementation of the algorithm as there are multiple correct outputs
            // for a given input. For the array [0, 1] the two acceptable outputs are:
            //   0           1
            //    \   AND   /
            //     1       0

            // 1 element
            var expectedResult = TreeHelpers.CreateBinaryTree(
                data: 0);

            ValidateInput(1, expectedResult);

            // 2 elements
            expectedResult = TreeHelpers.CreateBinaryTree(
                data: 0,
                    left: null,
                    right: new BinaryTreeNode<int>(1));

            ValidateInput(2, expectedResult);

            // 3 elements
            expectedResult = TreeHelpers.CreateBinaryTree(
                data: 1,
                    left: 0,
                    right: 2);

            ValidateInput(3, expectedResult);

            // 4 elements
            expectedResult = TreeHelpers.CreateBinaryTree(
                data: 1,
                    left: TreeHelpers.CreateBinaryTree(
                        data: 0),
                    right: TreeHelpers.CreateBinaryTree(
                        data: 2,
                            left: null,
                            right: new BinaryTreeNode<int>(3)));

            ValidateInput(4, expectedResult);

            // 5 elements
            expectedResult = TreeHelpers.CreateBinaryTree(
                data: 2,
                    left: TreeHelpers.CreateBinaryTree(
                        data: 0,
                            left: null,
                            right: new BinaryTreeNode<int>(1)),
                    right: TreeHelpers.CreateBinaryTree(
                        data: 3,
                            left: null,
                            right: new BinaryTreeNode<int>(4)));

            ValidateInput(5, expectedResult);

            // 6 elements
            expectedResult = TreeHelpers.CreateBinaryTree(
                data: 2,
                    left: TreeHelpers.CreateBinaryTree(
                        data: 0,
                            left: null,
                            right: new BinaryTreeNode<int>(1)),
                    right: TreeHelpers.CreateBinaryTree(
                        data: 4,
                            left: 3,
                            right: 5));

            ValidateInput(6, expectedResult);

            // 7 elements
            expectedResult = TreeHelpers.CreateBinaryTree(
                data: 3,
                    left: TreeHelpers.CreateBinaryTree(
                        data: 1,
                            left: 0,
                            right: 2),
                    right: TreeHelpers.CreateBinaryTree(
                        data: 5,
                            left: 4,
                            right: 6));

            ValidateInput(7, expectedResult);

            // 8 elements
            expectedResult = TreeHelpers.CreateBinaryTree(
                data: 3,
                    left: TreeHelpers.CreateBinaryTree(
                        data: 1,
                            left: 0,
                            right: 2),
                    right: TreeHelpers.CreateBinaryTree(
                        data: 5,
                            left: TreeHelpers.CreateBinaryTree(
                                data: 4),
                            right: TreeHelpers.CreateBinaryTree(
                                data: 6,
                                    left: null,
                                    right: new BinaryTreeNode<int>(7))));

            ValidateInput(8, expectedResult);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            TestHelpers.AssertExceptionThrown(() => Question4_2.MakeMinimalBinarySearchTree(null), typeof(ArgumentNullException));
        }

        private static void ValidateInput(int size, BinaryTreeNode<int> expectedResult)
        {
            var result = Question4_2.MakeMinimalBinarySearchTree(Enumerable.Range(0, size).ToArray());
            TreeHelpers.AssertBinaryTreesAreEqual(result, expectedResult);
        }
    }
}
