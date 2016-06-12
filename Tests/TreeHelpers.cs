using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public static class TreeHelpers
    {
        public static TreeNode<T> CreateTree<T>(T data, params T[] children)
            where T : IEquatable<T>
        {
            var childrenNodes = children?.Select(c => new TreeNode<T>(c, null));
            return new TreeNode<T>(data, childrenNodes);
        }

        public static TreeNode<T> CreateTree<T>(T data, params TreeNode<T>[] children)
            where T : IEquatable<T>
        {
            return new TreeNode<T>(data, children);
        }

        [SuppressMessage("Microsoft.Design", "CA1062")]
        public static void AssertTreesAreEqual<T>(TreeNode<T> first, TreeNode<T> second)
            where T : IEquatable<T>
        {
            if (first == null && second == null)
            {
                return;
            }

            Assert.IsNotNull(first);
            Assert.IsNotNull(second);
            Assert.AreEqual(first.Data, second.Data);

            if (first.Children == null && second.Children == null)
            {
                return;
            }

            Assert.IsTrue(first != null && second != null && first.Children.Length == second.Children.Length);

            for (int i = 0; i < first.Children.Length; i++)
            {
                AssertTreesAreEqual(first.Children[i], second.Children[i]);
            }
        }
    }
}
