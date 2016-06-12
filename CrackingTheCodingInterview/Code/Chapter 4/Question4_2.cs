using System;

namespace Code
{
    public static class Question4_2
    {
        // 4.2 Minimal Tree: Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a
        // binary search tree with minimal height.

        // Space: O(N)
        // Time: O(N)
        public static TreeNode<int> MakeMinimalBinarySearchTree(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return MakeMinimalBinarySearchTree(input, 0, input.Length - 1);
        }

        private static TreeNode<int> MakeMinimalBinarySearchTree(int[] input, int start, int end)
        {
            if (end < start)
            {
                return null;
            }

            var middle = (start + end) / 2;
            var left = MakeMinimalBinarySearchTree(input, start, middle - 1);
            var right = MakeMinimalBinarySearchTree(input, middle + 1, end);

            return new TreeNode<int>(input[middle], new[] { left, right });
        }
    }
}
