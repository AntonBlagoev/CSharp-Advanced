/*CustomStack with following methods:
* 
* Public methods:
*  Push
*  Pop
*  Peek
*  Count /prop/
*  Contains
*  Clear
*  ForEach
*
* Private methods:
*  Resize
*  Shrink
*  ShiftRight
*  ShiftLeft
*/

using System;
using System.Collections;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack<int> myCustomStack = new CustomStack<int>();
            Stack systemStack = new Stack();

            //Testing PUSH

            Console.WriteLine("Testing PUSH\n");

            for (int i = 0; i < 20; i++)
            {
                myCustomStack.Push(i);
                systemStack.Push(i);
            }
            Console.WriteLine(myCustomStack);
            foreach (var item in systemStack)
            {
                Console.Write($"{item} ");
            }

            // Testing POP

            Console.WriteLine("\n\nTesting POP\n");

            int stackCount = myCustomStack.Count;
            for (int i = 0; i < stackCount - 11; i++)
            {
                myCustomStack.Pop();
                systemStack.Pop();
            }

            Console.WriteLine(myCustomStack);
            foreach (var item in systemStack)
            {
                Console.Write($"{item} ");
            }

            //Testing PEEK

            Console.WriteLine("\n\nTesting PEEK\n");

            Console.WriteLine(myCustomStack.Peek());
            Console.WriteLine(systemStack.Peek());

            //Testing COUNT

            Console.WriteLine("\nTesting COUNT\n");

            int count1 = myCustomStack.Count;
            int count2 = systemStack.Count;
            Console.WriteLine(count1);
            Console.WriteLine(count2);

            //Testing CONTAINS

            Console.WriteLine("\nTesting CONTAINS\n");

            Console.WriteLine(myCustomStack.Contains(9)); // True
            Console.WriteLine(systemStack.Contains(9)); // True
            Console.WriteLine(myCustomStack.Contains(19)); // False
            Console.WriteLine(systemStack.Contains(19)); // False

            //Testing FOREACH

            Console.WriteLine("\nTesting FOREACH\n");

            myCustomStack.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
            foreach (var item in systemStack)
            {
                Console.Write($"{item} ");
            }

            //Testing CLEAR

            Console.WriteLine("\n\nTesting CLEAR\n");

            myCustomStack.Clear();
            systemStack.Clear();

            myCustomStack.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
            foreach (var item in systemStack)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
