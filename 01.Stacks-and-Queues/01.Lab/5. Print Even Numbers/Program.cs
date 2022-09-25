using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> inputQueue = new Queue<int>(inputNumbers);
            Queue<int> evenQueue = new Queue<int>();

            while (inputQueue.Count > 0)
            {
                if (inputQueue.Peek() % 2 == 0)
                {
                    evenQueue.Enqueue(inputQueue.Dequeue());
                }
                else
                {
                    inputQueue.Dequeue();
                }
            }
            Console.Write(string.Join(", ", evenQueue));
        }
    }
}
