using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputArr = Console.ReadLine().Split();
            Stack<string> myStack = new Stack<string>(inputArr.Reverse());

            int result = int.Parse(myStack.Pop());

            while (myStack.Count > 0)
            {
                string calcOperator = myStack.Pop();
                if (calcOperator == "+")
                {
                    result += int.Parse(myStack.Pop());
                }
                else
                {
                    result -= int.Parse(myStack.Pop());
                }
            }
            Console.WriteLine(result);
        }
    }
}
