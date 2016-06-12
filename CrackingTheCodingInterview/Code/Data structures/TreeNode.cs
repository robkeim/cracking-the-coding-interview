using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Code
{
    // This Node implementation is directly from the book (modified as needed)
    [DebuggerDisplay("Data = {Data}, Children = {DebuggerDisplay}")]
    public class TreeNode<T>
        where T : IEquatable<T>
    {
        public TreeNode(T data)
        {
            Data = data;
            Children = new TreeNode<T>[0];
        }

        [SuppressMessage("Microsoft.Design", "CA1006")]
        public TreeNode(T data, IEnumerable<TreeNode<T>> children)
        {
            Data = data;
            Children = children?.ToArray() ?? new TreeNode<T>[0];
        }

        public T Data { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1819")]
        public TreeNode<T>[] Children { get; set; }

        private string DebuggerDisplay => string.Join("_", Children.Select(c => c?.Data.ToString() ?? "null"));
    }
}
