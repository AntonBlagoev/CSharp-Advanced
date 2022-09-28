using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            int n = input[0];
            int m = input[1];

            HashSet<int> setN = new HashSet<int>();
            HashSet<int> setM = new HashSet<int>();

            for (int i = 0; i < (n + m); i++)
            {
                int inputNumbers = int.Parse(Console.ReadLine());

                if (i < n)
                {
                    setN.Add(inputNumbers);
                }
                else
                {
                    setM.Add(inputNumbers);
                }
            }
            Console.WriteLine(string.Join(" ", setN.Intersect(setM)));
            
            //foreach (var number in setN)
            //{
            //    if (setM.Contains(number))
            //    {
            //        Console.Write($"{number} ");
            //    }
            //}
        }
    }
}
