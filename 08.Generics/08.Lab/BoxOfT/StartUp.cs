using System;
using System.Collections.Generic;

namespace BoxOfT
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            Console.WriteLine(box.Remove());

        }
    }

    public class Box<T>
    {
        private List<T> list;
        private int count;
        public Box()
        {
            list = new List<T>();
        }
        public int Count { get { return list.Count; } }
        public void Add(T element)
        {
            list.Add(element);
            this.count++;
        }
        public T Remove()
        {
            var removedElement = list[this.count - 1];
            list.RemoveAt(this.count - 1);
            this.count--;
            return removedElement;
        }
    }
}
