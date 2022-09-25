using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNumbers = Console.ReadLine()
                .Split().Select(int.Parse)
                .OrderByDescending(x => x)
                .ToArray();

            for (int i = 0; i < inputNumbers.Length && i < 3; i++)
            {
                Console.Write($"{inputNumbers[i]} ");
            }

        }
    }
}
