using System;

namespace Code
{
    public static class Question4_4
    {
        // 4.4 Check Balanced: Implement a function to check if a binary tree is balanced. For the purpose
        // of this question, a balanced tree is defined to be a tree such that the heights of the two subtrees
        // of any node never differ by more than one

        // Space: O(1)
        // Time: O(N log N)
        public static bool IsBalanced<T>(BinaryTreeNode<T> root)
            where T : IEquatable<T>
        {
            if (root == null)
            {
                return true;
            }

            var leftHeight = GetHeight(root.Left);
            var rightHeight = GetHeight(root.Right);

            return Math.Abs(leftHeight - rightHeight) <= 1
                && IsBalanced(root.Left)
                && IsBalanced(root.Right);
        }

        private static int GetHeight<T>(BinaryTreeNode<T> root)
            where T : IEquatable<T>
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
        }
    }
}
