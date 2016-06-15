using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Code
{
    public static class Question4_3
    {
        // 4.3 List of Depths: Given a binary tree, design an algorithm which creates a linked list of all of the nodes at
        // each depth (e.g., if you have a tree with depth D, you'll have D linked lists).

        // Space: O(N)
        // Time: O(N)
        [SuppressMessage("Microsoft.Design", "CA1006")]
        public static List<List<BinaryTreeNode<T>>> FindDepths<T>(BinaryTreeNode<T> root)
            where T : IEquatable<T>
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            var result = new List<List<BinaryTreeNode<T>>>();
            var curList = new List<BinaryTreeNode<T>>
            {
                root
            };

            while (curList.Count > 0)
            {
                var nextList = new List<BinaryTreeNode<T>>();
                var curResult = new List<BinaryTreeNode<T>>();

                while (curList.Count > 0)
                {
                    var cur = curList[0];
                    curList.RemoveAt(0);
                    curResult.Add(cur);

                    if (cur.Left != null)
                    {
                        nextList.Add(cur.Left);
                    }

                    if (cur.Right != null)
                    {
                        nextList.Add(cur.Right);
                    }
                }

                result.Add(curResult);
                curList = nextList;
            }

            return result;
        }
    }
}
