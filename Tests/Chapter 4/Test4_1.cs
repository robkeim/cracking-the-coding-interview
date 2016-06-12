using System;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Test4_1
    {
        [TestMethod]
        public void BasicTest()
        {
            var first = new TreeNode<int>(0);
            var second = new TreeNode<int>(0);
            ValidateResult(first, second, true);

            second = new TreeNode<int>(1);
            ValidateResult(first, second, false);

            first = TreeHelpers.CreateTree(0, 1, 2, 3);
            second = TreeHelpers.CreateTree(3, 4, 5);
            ValidateResult(first, second, true);

            var tmp1 = TreeHelpers.CreateTree(1, 2, 3);
            var tmp2 = TreeHelpers.CreateTree(4, 5, 6);
            first = TreeHelpers.CreateTree(7, tmp1, tmp2);
            second = new TreeNode<int>(6);
            ValidateResult(first, second, true);
        }

        [TestMethod]
        public void InvalidInputTest()
        {
            var tree = new TreeNode<int>(0, null);

            TestHelpers.AssertExceptionThrown(() => { Question4_1.AreConnected(null, tree); }, typeof(ArgumentNullException));
            TestHelpers.AssertExceptionThrown(() => { Question4_1.AreConnected(tree, null); }, typeof(ArgumentNullException));
        }

        private static void ValidateResult<T>(TreeNode<T> first, TreeNode<T> second, bool expectedValue)
            where T : IEquatable<T>
        {
            Assert.AreEqual(expectedValue, Question4_1.AreConnected(first, second));
        }
    }
}
