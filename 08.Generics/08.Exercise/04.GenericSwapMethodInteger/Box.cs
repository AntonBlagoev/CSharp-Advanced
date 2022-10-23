using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
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
        public void Swap(int indexOne, int indexTwo)
        {
            var temp = this.list[indexOne];
            this.list[indexOne] = this.list[indexTwo];
            this.list[indexTwo] = temp;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            string result = sb.ToString();

            return result;
        }
    }
}
