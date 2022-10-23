/*CustomList with following methods:
* 
* Public methods:
*  Add
*  AddRange
*  RemoveAt
*  RemoveRange
*  InsertAt
*  InsertRange
*  Contains
*  Swap
*  Revers
*  FindIndex
*  ForEach
*  ToString
*
* Private methods:
*  Resize
*  Shrink
*  ShiftLeft
*  ShiftRight
*  CheckIndex
*/

using System;
using System.Collections.Generic;

namespace CustomList
{
    class StratUp
    {
        static void Main(string[] args)
        {
            CustomList<int> myCustomList = new CustomList<int>();
            List<int> systemList = new List<int>();

            //Testing Add

            Console.WriteLine("Testing ADD\n");
            int n = 20;
            for (int i = 0; i < n; i++)
            {
                myCustomList.Add(i);
                systemList.Add(i);
            }
            Console.WriteLine(myCustomList);
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }

            //Testing AddRange

            Console.WriteLine("\n\nTesting AddRange\n");

            myCustomList.AddRange(new int[] { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 });
            systemList.AddRange(new int[] { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 });
            Console.WriteLine(myCustomList);
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }

            //Testing RemoveAt

            Console.WriteLine("\n\nTesting RemoveAt\n");

            myCustomList.RemoveAt(2);
            systemList.RemoveAt(2);
            Console.WriteLine(myCustomList);
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }

            //Testing RemoveRange

            Console.WriteLine("\n\nTesting RemoveRange\n");

            myCustomList.RemoveRange(0, 19);
            systemList.RemoveRange(0, 19);
            Console.WriteLine(myCustomList);
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }

            //Testing Insert

            Console.WriteLine("\n\nTesting InsertAt\n");

            myCustomList.Insert(0, -42);
            systemList.Insert(0, -42);
            Console.WriteLine(myCustomList);
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }

            //Testing InsertRange

            Console.WriteLine("\n\nTesting InsertRange\n");

            myCustomList.InsertRange(0, new int[] { 100, 200, 300, 400, 500, 600 });
            systemList.InsertRange(0, new int[] { 100, 200, 300, 400, 500, 600 });
            Console.WriteLine(myCustomList);
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }

            //Testing Contains

            Console.WriteLine("\n\nTesting Contains\n");

            Console.WriteLine(myCustomList.Contains(-42)); 
            Console.WriteLine(systemList.Contains(-42));
            
            //Testing Revers

            Console.WriteLine("\n\nTesting Revers\n")
                ;
            myCustomList.Reverse();
            systemList.Reverse();
            Console.WriteLine(myCustomList);
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }

            //Testing Swap

            Console.WriteLine("\n\nTesting Swap\n");

            myCustomList.Swap(0, 6);
            Console.WriteLine(myCustomList);
            var tmp = systemList[0];
            systemList[0] = systemList[6];
            systemList[6] = tmp;
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }


            //Testing FindIndex

            Console.WriteLine("\n\nTesting FindIndex\n");

            Console.WriteLine(myCustomList.FindIndex(142));
            //Console.WriteLine(myCustomList.FindIndex(142));
            Console.WriteLine(myCustomList.FindIndex(444));
            //Console.WriteLine(systemList.FindIndex(444));


            //Testing ForEach

            Console.WriteLine("\n\nTesting ForEach\n");


            myCustomList.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
            systemList.ForEach(i => Console.Write(i + " "));
            Console.WriteLine();
            foreach (var item in systemList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            Console.WriteLine(myCustomList.ToString());

        }
    }
}
