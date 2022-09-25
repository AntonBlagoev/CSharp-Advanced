using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n))
                .ToArray();
            
            Dictionary<double, int> numbersDict = new Dictionary<double, int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (!numbersDict.ContainsKey(inputNumbers[i]))
                {
                    numbersDict.Add(inputNumbers[i], 0);
                }

                numbersDict[inputNumbers[i]] += 1;

            }

            foreach (var number in numbersDict)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
