using System;
using System.Collections;
using System.Collections.Generic;
namespace LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }       
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public LinkedList(Node<T> newNode)
        {
            Head = newNode;
            Tail = newNode;
            Count = 1;
        }
        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (Tail != null)
            {
                Tail.Next = node;
                Tail = node;
                Count++;
            }
            else
            {
                Head = node;
                Tail = node;
                Count = 1;
            }
        }
        public void Remove(T data)
        {
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    ItemWasRemoved?.Invoke(data);
                    return;
                }

                var current = Head.Next;
                var previous = Head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        ItemWasRemoved?.Invoke(data);
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }

            }

        }
        public int IndexOf(T node)
        {
            Node<T> current = Head;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data.Equals(node)) return i;

                current = current.Next;
            }
            return -1;
        }
        public bool Contains(T node)
        {
            return IndexOf(node) >= 0;
        }
        public T this[int index]
        {
            get { return Get(index); }
        }
        private T Get(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index" + index);
            }

            if (index >= Count)
            {
                index = Count - 1;
            }

            Node<T> current = Head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable<T> EvenNumbers()
        {
            var current = Head;

            while (current != null)
            {
                if (Convert.ToInt32(current.Data) % 2 == 0 && Convert.ToInt32(current.Data) != 0)
                {
                    yield return current.Data;

                }
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Except(LinkedList<T> list, LinkedList<T> exceptList)
        {
            foreach (var item in list)
            {
                if (exceptList.Contains((T)item))
                {
                    list.Remove((T)item);
                }

            }

        }

        public delegate LinkedList<T> MyFilterDelegate(LinkedList<T> list);

        private MyFilterDelegate myFilter;
        public void RegisterOnMyFilter(MyFilterDelegate myFilter)
        {
            this.myFilter += myFilter;
        }
        public void UnregisterOnMyFilter(MyFilterDelegate myFilter)
        {
            this.myFilter -= myFilter;
        }

        public LinkedList<T> FilterMyList(LinkedList<T> list)
        {
            return myFilter?.Invoke(list);
        }

        public event Action<T> ItemWasRemoved;
       
    }
}
