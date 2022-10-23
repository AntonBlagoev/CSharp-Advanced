using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> items;
        public Stack()
        {
            this.items = new List<T>();
        }
        public int Count { get; private set; }

        public void Push(T item)
        {
            
            this.items.Insert(0, item);
            this.Count++;
        }
        public void Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            this.items.RemoveAt(0);
            this.Count--;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                yield return this.items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
