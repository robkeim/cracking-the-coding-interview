using System;
using System.Diagnostics;

namespace Code
{
    // This Node implementation is directly from the book (modified as needed)
    [DebuggerDisplay("Data = {Data}")]
    public class Node<T>
        where T : IEquatable<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public void AppendToTail(T data)
        {
            var end = new Node<T>(data);
            Node<T> n = this;

            while (n.Next != null)
            {
                n = n.Next;
            }

            n.Next = end;
        }

        public Node<T> DeleteNode(Node<T> head, T data)
        {
            if (head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            Node<T> n = head;

            if (n.Data.Equals(data))
            {
                return head.Next; // Moved head
            }

            while (n.Next != null)
            {
                if (n.Next.Data.Equals(data))
                {
                    n.Next = n.Next.Next;
                    return head; // head didn't change
                }

                n = n.Next;
            }

            return head;
        }
    }
}
