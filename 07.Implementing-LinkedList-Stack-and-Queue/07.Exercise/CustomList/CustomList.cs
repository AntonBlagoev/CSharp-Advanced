using System;

namespace CustomList
{
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;
        private T[] items;
        public int Count { get; private set; }
        public CustomList()
        {
            this.items = new T[InitialCapacity];
        }
        public T this[int index]
        {
            get
            {
                this.CheckIndex(index);
                return this.items[index];
            }
            set
            {
                this.CheckIndex(index);
                this.items[index] = value;
            }
        }
        public void Add(T item)
        {
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        public void AddRange(T[] array)
        {
            foreach (var item in array)
            {
                this.Add(item);
            }
        }
        public T RemoveAt(int index)
        {
            this.CheckIndex(index);
            var removedItem = this.items[index];
            this.items[index] = default(T);
            this.ShiftLeft(index);
            Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
            return removedItem;
        }
        public void RemoveRange(int index, int count)
        {
            this.CheckIndex(index);
            for (int i = index; i < count; i++)
            {
               this.RemoveAt(index);
            }
        }
        public void Insert(int index, T item)
        {
            this.CheckIndex(index);
            if (this.items.Length == this.Count)
            {
                this.Resize();
            }
            this.ShiftRight(index);
            items[index] = item;
            Count++;
        }
        public void InsertRange(int index, T[] array)
        {
            this.CheckIndex(index);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                this.Insert(index, array[i]);
            }
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            this.CheckIndex(firstIndex);
            this.CheckIndex(secondIndex);

            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }
        public void Reverse()
        {
            T[] reversedItems = new T[this.Count];
            int reversedCount = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                reversedItems[reversedCount] = this.items[i];
                reversedCount++;
            }
            this.items = reversedItems;
        }
        public int FindIndex(T item)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (this.items[i].Equals(item))
                {
                    index = i;
                    return index;
                }
            }
            return index;

        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                T currentItem = this.items[i];
                action(currentItem);
            }
        }
        public  override string ToString()
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
        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
        }
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

    }
}
