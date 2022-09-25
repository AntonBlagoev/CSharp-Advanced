using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] inputChars = Console.ReadLine().ToCharArray();
            Stack<char> myStack = new Stack<char>();
            bool isValid = true;

            foreach (var currInputChar in inputChars)
            {
                if (currInputChar == '{' || currInputChar == '(' || currInputChar == '[')
                {
                    myStack.Push(currInputChar);
                }
                else if (currInputChar == '}' || currInputChar == ')' || currInputChar == ']')
                {
                    if (myStack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    if (currInputChar == '}' && myStack.Peek() == '{')
                    {
                        myStack.Pop();
                    }
                    else if (currInputChar == ')' && myStack.Peek() == '(')
                    {
                        myStack.Pop();
                    }
                    else if (currInputChar == ']' && myStack.Peek() == '[')
                    {
                        myStack.Pop();
                    }
                }
                else
                {
                    isValid = false;
                    break;
                }
            }

            if (myStack.Count == 0 && isValid)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
