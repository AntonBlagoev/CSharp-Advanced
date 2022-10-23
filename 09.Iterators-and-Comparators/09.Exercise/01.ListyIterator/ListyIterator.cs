using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> items;
        private int index;
        public ListyIterator(List<T> items)
        {
            this.items = items;
        }
        
        public  bool Move()
        {
            if (this.index == this.items.Count - 1)
            {
                return false;
            }
            index++;
            return true;
        }
        public bool HasNext()
        {
            if (this.index == this.items.Count - 1)
            {
                return false;
            }
            return true;
        }
        public void Print()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine($"{this.items[this.index]}");

        }
        
    }
}
