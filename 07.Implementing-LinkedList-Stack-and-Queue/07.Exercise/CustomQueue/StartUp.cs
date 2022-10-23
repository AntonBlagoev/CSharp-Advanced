/*CustomQueue with following methods:
* 
* Public methods:
*  Enqueue
*  Dequeue
*  Peek
*  Count /field/
*  Contains
*  Clear
*  ForEach
*
* Private methods:
*  Resize
*  Shrink
*  ShiftLeft
*/
using System;
using System.Collections.Generic;

namespace CustomQueue
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomQueue<int> myCustomQueue = new CustomQueue<int>();
            Queue<int> systemQueue = new Queue<int>();

            //Testing Enqueue

            Console.WriteLine("Testing Enqueue\n");

            for (int i = 0; i < 20; i++)
            {
                myCustomQueue.Enqueue(i);
                systemQueue.Enqueue(i);
            }
            Console.WriteLine(myCustomQueue);
            foreach (var item in systemQueue)
            {
                Console.Write($"{item} ");
            }

            // Testing Dequeue

            Console.WriteLine("\n\nTesting Dequeue\n");

            int queueCount = myCustomQueue.Count;
            for (int i = 0; i < queueCount - 11; i++)
            {
                myCustomQueue.Dequeue();
                systemQueue.Dequeue();
            }

            Console.WriteLine(myCustomQueue);
            foreach (var item in systemQueue)
            {
                Console.Write($"{item} ");
            }

            //Testing PEEK

            Console.WriteLine("\n\nTesting PEEK\n");

            Console.WriteLine(myCustomQueue.Peek());
            Console.WriteLine(systemQueue.Peek());

            //Testing COUNT

            Console.WriteLine("\nTesting COUNT\n");

            int count1 = myCustomQueue.Count;
            int count2 = systemQueue.Count;
            Console.WriteLine(count1);
            Console.WriteLine(count2);

            //Testing CONTAINS

            Console.WriteLine("\nTesting CONTAINS\n");

            Console.WriteLine(myCustomQueue.Contains(9)); // True
            Console.WriteLine(systemQueue.Contains(9)); // True
            Console.WriteLine(myCustomQueue.Contains(119)); // False
            Console.WriteLine(systemQueue.Contains(119)); // False

            //Testing FOREACH

            Console.WriteLine("\nTesting FOREACH\n");

            myCustomQueue.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
            foreach (var item in systemQueue)
            {
                Console.Write($"{item} ");
            }

            //Testing CLEAR

            Console.WriteLine("\n\nTesting CLEAR\n");

            myCustomQueue.Clear();
            systemQueue.Clear();

            myCustomQueue.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
            foreach (var item in systemQueue)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
