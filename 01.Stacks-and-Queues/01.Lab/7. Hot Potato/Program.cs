using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> childrensQueue = new Queue<string>(Console.ReadLine().Split());
            int nToss = int.Parse(Console.ReadLine());
            int count = 1;

            while (childrensQueue.Count > 1)
            {
                if (count == nToss)
                {
                    Console.WriteLine($"Removed {childrensQueue.Dequeue()}");
                    count = 1;
                    continue;
                }
                string tmpChild = childrensQueue.Dequeue();
                childrensQueue.Enqueue(tmpChild);
                count++;
            }
            Console.WriteLine($"Last is {string.Join("", childrensQueue)}");
        }
    }
}
