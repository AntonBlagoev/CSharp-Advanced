using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int nunberOfQueries = int.Parse(Console.ReadLine());

            Stack<int> myStack = new Stack<int>();

            for (int i = 0; i < nunberOfQueries; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (tokens[0])
                {
                    case 1:
                        myStack.Push(tokens[1]);
                        break;
                    case 2:
                        if (myStack.Count > 0)
                        {
                            myStack.Pop();
                        }
                        break;
                    case 3:
                        if (myStack.Count > 0)
                        {
                            Console.WriteLine(myStack.Max());
                        }
                        break;
                    case 4:
                        if (myStack.Count > 0)
                        {
                            Console.WriteLine(myStack.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", myStack));
        }
    }
}
