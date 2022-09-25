using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string inputCommands = string.Empty;
            while ((inputCommands = Console.ReadLine().ToLower()) != "end")
            {
                string[] commands = inputCommands.Split();

                if (commands[0] == "add")
                {
                    myStack.Push(int.Parse(commands[1]));
                    myStack.Push(int.Parse(commands[2]));
                }
                else if (commands[0] == "remove")
                {
                    int numberToRemove = int.Parse(commands[1]);
                    if (myStack.Count >= numberToRemove)
                    {
                        for (int i = 0; i < numberToRemove; i++)
                        {
                            myStack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {myStack.Sum()}");
        }
    }
}
