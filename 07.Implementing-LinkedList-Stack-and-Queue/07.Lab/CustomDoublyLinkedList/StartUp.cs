using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<int> myCustomLinkedList = new CustomDoublyLinkedList<int>();
            LinkedList<int> systemLinkedList = new LinkedList<int>();

            // Testing AddFirst
            Console.WriteLine("Testing AddFirst\n");

            for (int i = 55; i < 58; i++)
            {
                myCustomLinkedList.AddFirst(i);
                systemLinkedList.AddFirst(i);
            }
            Console.WriteLine(String.Join(",", myCustomLinkedList.ToArray()));
            Console.WriteLine(String.Join(",", systemLinkedList));

            // Testing AddLast
            Console.WriteLine("\nTesting AddLast\n");

            for (int i = 100; i < 104; i++)
            {
                myCustomLinkedList.AddLast(i);
                systemLinkedList.AddLast(i);
            }
            Console.WriteLine(String.Join(",", myCustomLinkedList.ToArray()));
            Console.WriteLine(String.Join(",", systemLinkedList));

            // Testing RemoveFirst
            Console.WriteLine("\nTesting RemoveFirst\n");

            myCustomLinkedList.RemoveFirst();
            systemLinkedList.RemoveFirst();
            Console.WriteLine(String.Join(",", myCustomLinkedList.ToArray()));
            Console.WriteLine(String.Join(",", systemLinkedList));

            // Testing RemoveLast
            Console.WriteLine("\nTesting RemoveLast\n");

            myCustomLinkedList.RemoveLast();
            systemLinkedList.RemoveLast();
            Console.WriteLine(String.Join(",", myCustomLinkedList.ToArray()));
            Console.WriteLine(String.Join(",", systemLinkedList));

            // Testing system Foreach
            Console.WriteLine("\nTesting system Foreach\n");
            foreach (var item in myCustomLinkedList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in systemLinkedList)
            {
                Console.Write($"{item} ");
            }

            // Testing Reverse
            Console.WriteLine("\n\nTesting Reverse\n");
            myCustomLinkedList.Reverse();
            systemLinkedList.Reverse();
            Console.WriteLine(String.Join(",", myCustomLinkedList.ToArray()));
            Console.WriteLine(String.Join(",", systemLinkedList.Reverse()));


        }
    }
}
