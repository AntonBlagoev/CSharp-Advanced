using System;

namespace CustomQueue
{
    public class CustomQueue<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int count;
        public CustomQueue()
        {
            this.items = new T[InitialCapacity];
        }
        public int Count
        {
            get { return this.count; }
        }
        public void Enqueue(T item)
        {
            if (this.items.Length == this.count)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.count++;
        }
        public T Dequeue()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException("CustomQueue is empty");
            }
            T dequeueItem = this.items[0];
            this.ShiftLeft();
            this.count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
            return dequeueItem;
        }

        public T Peek()
        {
            return this.items[0];
        }
        public void Clear()
        {
            T[] emptyItems = new T[InitialCapacity];
            this.items = emptyItems;
            count = 0;
        }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
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


        private void Resize()
        {
            T[] tempArr = new T[this.items.Length * 2];
            items.CopyTo(tempArr, 0);
            this.items = tempArr;
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
        private void ShiftLeft()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
    }
}
