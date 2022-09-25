using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputExpression = Console.ReadLine();
            Stack<int> myStack = new Stack<int>();

            for (int i = 0; i < inputExpression.Length; i++)
            {
                if (inputExpression[i] == '(')
                {
                    myStack.Push(i);
                }
                else if (inputExpression[i] == ')')
                {
                    int substringStartIndex = myStack.Pop();
                    int substringCount = i - substringStartIndex + 1;
                    Console.WriteLine(inputExpression.Substring(substringStartIndex,substringCount));
                }
            }
        }
    }
}
