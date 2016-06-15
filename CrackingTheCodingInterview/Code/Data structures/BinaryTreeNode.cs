using System;
using System.Diagnostics;

namespace Code
{
    // This BinaryTreeNode implementation is adapted from the TreeNode implementation in the book
    [DebuggerDisplay("Data = {Data}, Left = {Left?.Data}, Right = {Right?.Data}")]
    public class BinaryTreeNode<T>
        where T : IEquatable<T>
    {
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public T Data { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }
    }
}
