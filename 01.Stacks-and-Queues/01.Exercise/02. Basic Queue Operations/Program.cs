using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numbersToDequeue = inputArr[1];
            int numbersToFind = inputArr[2];

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> myQueue = new Queue<int>(inputNumbers);

            for (int i = 0; i < numbersToDequeue; i++)
            {
                if (myQueue.Count > 0)
                {
                    myQueue.Dequeue();
                }
            }

            if (myQueue.Contains(numbersToFind))
            {
                Console.WriteLine("true");
            }
            else if (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
