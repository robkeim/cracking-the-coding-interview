using System;
using System.Collections.Generic;

namespace Code
{
    // 4.1 Route Between Nodes: Given a directed graph, design an algorithm to find out whether there is a route between two nodes.

    // Space: O(N)
    // Time: O(N)
    public static class Question4_1
    {
        public static bool AreConnected<T>(TreeNode<T> start, TreeNode<T> end)
            where T : IEquatable<T>
        {
            if (start == null)
            {
                throw new ArgumentNullException(nameof(start));
            }

            if (end == null)
            {
                throw new ArgumentNullException(nameof(end));
            }

            var processedNodes = new HashSet<TreeNode<T>>();
            var nodesToVisit = new Queue<TreeNode<T>>();
            nodesToVisit.Enqueue(start);

            while (nodesToVisit.Count != 0)
            {
                var node = nodesToVisit.Dequeue();

                if (node.Data.Equals(end.Data))
                {
                    return true;
                }

                processedNodes.Add(node);

                if (node.Children != null)
                {
                    foreach (var child in node.Children)
                    {
                        if (!processedNodes.Contains(child))
                        {
                            nodesToVisit.Enqueue(child);
                        }
                    }
                }
            }

            return false;
        }
    }
}
