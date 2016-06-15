using System;
using System.Collections.Generic;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test4_3
    {
        [TestMethod]
        public void BasicTest()
        {
            // One node
            var root = new BinaryTreeNode<int>(0);
            var result = new List<List<int>>
            {
                ListHelpers.CreateList(0)
            };
            ValidateResult(result, root);

            // One node with children
            root = TreeHelpers.CreateBinaryTree(0, 1, 2);
            result = new List<List<int>>
            {
                ListHelpers.CreateList(0),
                ListHelpers.CreateList(1, 2)
            };
            ValidateResult(result, root);

            // More complex tree
            var tmp1 = TreeHelpers.CreateBinaryTree(4, 5, 6);
            var tmp2 = TreeHelpers.CreateBinaryTree(7, 8, 9);
            var tmp3 = TreeHelpers.CreateBinaryTree(3, tmp1, tmp2);
            var tmp4 = TreeHelpers.CreateBinaryTree(2, tmp3, null);
            root = TreeHelpers.CreateBinaryTree(0, new BinaryTreeNode<int>(1), tmp4);
            result = new List<List<int>>
            {
                ListHelpers.CreateList(0),
                ListHelpers.CreateList(1, 2),
                ListHelpers.CreateList(3),
                ListHelpers.CreateList(4, 7),
                ListHelpers.CreateList(5, 6, 8, 9)
            };
            ValidateResult(result, root);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            TestHelpers.AssertExceptionThrown(() => Question4_3.FindDepths<int>(null), typeof(ArgumentNullException));
        }

        private static void ValidateResult<T>(List<List<T>> expectedResults, BinaryTreeNode<T> root)
            where T : IEquatable<T>
        {
            var result = Question4_3.FindDepths(root);

            Assert.AreEqual(expectedResults.Count, result.Count);

            for (int i = 0; i < expectedResults.Count; i++)
            {
                Assert.AreEqual(expectedResults[i].Count, result[i].Count);

                for (int j = 0; j < expectedResults[i].Count; j++)
                {
                    Assert.AreEqual(expectedResults[i][j], result[i][j].Data);
                }
            }
        }
    }
}
