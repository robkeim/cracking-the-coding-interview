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

        public static TreeNode<int> CreateBinaryTree(int data)
        {
            return CreateBinaryTree(data, left: null, right: null);
        }

        [SuppressMessage("Microsoft.Design", "CA1026")]
        public static TreeNode<int> CreateBinaryTree(int data, int? left, int? right)
        {
            var leftNode = left != null ? CreateBinaryTree(left.Value) : null;
            var rightNode = right != null ? CreateBinaryTree(right.Value) : null;

            return new TreeNode<int>(data, new[] { leftNode, rightNode });
        }

        public static TreeNode<int> CreateBinaryTree(int data, TreeNode<int> leftNode, TreeNode<int> rightNode)
        {
            return new TreeNode<int>(data, new[] { leftNode, rightNode });
        }
    }
}
