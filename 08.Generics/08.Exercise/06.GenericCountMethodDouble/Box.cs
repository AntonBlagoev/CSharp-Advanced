using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> list;
        public Box()
        {
            list = new List<T>();
        }
        public List<T> List { get; set; }
        public void Add(T item)
        {
            list.Add(item);
        }
        public int GetMax(T compareValue)
        {
            int countMax = 0;
            foreach (var item in this.list)
            {
                if (item.CompareTo(compareValue) == 1)
                {
                    countMax++;
                }
            }
            return countMax;
        }
    }
}
