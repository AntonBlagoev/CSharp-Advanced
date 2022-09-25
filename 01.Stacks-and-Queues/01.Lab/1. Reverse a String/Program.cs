using System;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();
            Stack<char> myStack = new Stack<char>(inputText);

            while (myStack.Count > 0)
            {
                Console.Write(myStack.Pop());
            }
        }
    }
}
