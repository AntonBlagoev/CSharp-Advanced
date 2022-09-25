using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customersQueue = new Queue<string>();
            int customersCount = 0;

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    while (customersQueue.Count > 0)
                    {
                        Console.WriteLine(customersQueue.Dequeue());
                    }
                    customersCount = 0;
                    continue;
                }
                customersQueue.Enqueue(input);
                customersCount++;
            }
            Console.WriteLine($"{customersCount} people remaining.");
        }
    }
}
