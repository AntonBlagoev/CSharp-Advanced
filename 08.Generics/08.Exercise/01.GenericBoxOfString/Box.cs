using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        private List<T> list;
        public Box()
        {
            list = new List<T>();
        }
        public void Add(T item)
        {
            list.Add(item);
        }
        public List<T> List { get; set; }
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
