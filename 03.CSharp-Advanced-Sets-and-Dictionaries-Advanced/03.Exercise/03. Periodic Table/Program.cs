using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> periodicTable = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                periodicTable.UnionWith(inputElements);

                //foreach (var element in inputElements)
                //{
                //    periodicTable.Add(element);
                //}
            }
            Console.WriteLine(string.Join(" ", periodicTable.OrderBy(x => x).ToHashSet()));
        }
    }
}
