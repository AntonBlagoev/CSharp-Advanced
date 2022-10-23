using System;

namespace CustomStack
{
    public class CustomStack<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int count;

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
        }
        public int Count
        {
            get { return this.count; }
        }
        public void Push(T item)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }
            this.ShiftRight();
            this.items[0] = item;
            this.count++;
        }
        public void Pop()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException("CustomStack is empty");
            }
            this.ShiftLeft();
            this.count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
        }
        public T Peek()
        {
            return this.items[0];
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        public T[] Clear()
        {
            T[] emptyItems = new T[InitialCapacity];
            this.items = emptyItems;
            count = 0;
            return items;
        }
        public override string ToString()
        {
            T[] printItems = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                printItems[i] = this.items[i];
            }
            return string.Join(' ', printItems); ;
        }


        private void Resize()
        {
            T[] copy = new T[this.items.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void Shrink()
        {
            T[] copy = new T[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void ShiftRight()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                this.items[i + 1] = this.items[i];
            }
        }
        private void ShiftLeft()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
    }
}
