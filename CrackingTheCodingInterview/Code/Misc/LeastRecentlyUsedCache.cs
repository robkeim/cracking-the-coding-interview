using System;
using System.Collections.Generic;

namespace Code
{
    /// <summary>
    /// Implements a LRU (least recently used) cache
    /// </summary>
    /// <typeparam name="T">The type of item stored in the cache</typeparam>
    public class LeastRecentlyUsedCache<T>
    {
        private static readonly object _lockObj = new object();

        private readonly int _capacity;
        private readonly Dictionary<string, KeyValueNode<T>> _objects;
        private int _count;
        private KeyValueNode<T> _head;
        private KeyValueNode<T> _tail;

        public LeastRecentlyUsedCache(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive");
            }

            _capacity = capacity;
            _objects = new Dictionary<string, KeyValueNode<T>>(capacity);

            // Create dummy nodes for head/tail to make insertion/removal easier
            _head = new KeyValueNode<T>(null, default(T));
            _tail = new KeyValueNode<T>(null, default(T));

            _head.Next = _tail;
            _tail.Previous = _head;
        }

        public T Get(string key)
        {
            lock (_lockObj)
            {
                if (!_objects.ContainsKey(key))
                {
                    return default(T);
                }

                var node = _objects[key];
                DeleteNode(node);
                AddToHead(node);

                return node.Value;
            }
        }

        public void Set(string key, T value)
        {
            lock (_lockObj)
            {
                if (_objects.TryGetValue(key, out KeyValueNode<T> node))
                {
                    node.Value = value;
                    DeleteNode(node);
                    AddToHead(node);
                }
                else
                {
                    node = new KeyValueNode<T>(key, value);
                    _objects[key] = node;

                    if (_count < _capacity)
                    {
                        _count++;
                        AddToHead(node);
                    }
                    else
                    {
                        _objects.Remove(_tail.Previous.Key);
                        DeleteNode(_tail.Previous);
                        AddToHead(node);
                    }
                }
            }
        }

        private static void DeleteNode(KeyValueNode<T> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
        }

        private void AddToHead(KeyValueNode<T> node)
        {
            node.Next = _head.Next;
            node.Next.Previous = node;
            node.Previous = _head;
            _head.Next = node;
        }

        private class KeyValueNode<U>
        {
            public KeyValueNode(string key, U value)
            {
                Key = key;
                Value = value;
            }

            public string Key { get; }

            public U Value { get; set; }

            public KeyValueNode<U> Previous { get; set; }

            public KeyValueNode<U> Next { get; set; }
        }
    }
}
