using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsPassed = int.Parse(Console.ReadLine());
            int countOfCarsPassed = 0;

            Queue<string> carsQueue = new Queue<string>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < numberOfCarsPassed; i++)
                    {
                        if (carsQueue.Count > 0)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                            countOfCarsPassed++;
                        }
                    }
                    continue;
                }
                carsQueue.Enqueue(command);
            }
            Console.WriteLine($"{countOfCarsPassed} cars passed the crossroads.");
        }
    }
}
