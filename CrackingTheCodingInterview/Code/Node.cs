using System;
using System.Diagnostics;

namespace Code
{
    // This Node implementation is directly from the book (modified as needed)
    [DebuggerDisplay("Data = {Data}")]
    public class Node<T> where T : IEquatable<T>
    {
        public Node(T d)
        {
            Data = d;
        }

        public T Data { get; private set; }

        public Node<T> Next { get; set; }
        
        public void AppendToTail(T d)
        {
            Node<T> end = new Node<T>(d);
            Node<T> n = this;

            while (n.Next != null)
            {
                n = n.Next;
            }

            n.Next = end;
        }

        public Node<T> DeleteNode(Node<T> head, T d)
        {
            Node<T> n = head;

            if (n.Data.Equals(d))
            {
                return head.Next; // Moved head
            }

            while (n.Next != null)
            {
                if (n.Next.Data.Equals(d))
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
