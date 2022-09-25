using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numbersToPop = inputArr[1];
            int numbersToFind = inputArr[2];

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> myStack = new Stack<int>(inputNumbers);

            for (int i = 0; i < numbersToPop; i++)
            {
                if (myStack.Count > 0)
                {
                    myStack.Pop();
                }
            }

            if (myStack.Contains(numbersToFind))
            {
                Console.WriteLine("true");
            }
            else if (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
