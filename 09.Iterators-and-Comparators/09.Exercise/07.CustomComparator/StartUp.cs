using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.CustomComparator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            Console.WriteLine(string.Join(" ", ForCompare(numbers)));

            static int[] ForCompare(int[] numbers)
            {
                int[] sortedArray = new int[numbers.Length];
                List<int> oddList = new List<int>();
                List<int> evenList = new List<int>();
                
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        oddList.Add(numbers[i]);
                    }
                    else
                    {
                        evenList.Add(numbers[i]);
                    }
                }
                oddList.Sort();
                evenList.Sort();

                oddList.CopyTo(sortedArray);
                evenList.CopyTo(0, sortedArray, oddList.Count, evenList.Count);

                return sortedArray;
            }
        }
    }
}
