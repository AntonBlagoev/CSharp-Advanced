using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int rangeEnd = int.Parse(Console.ReadLine());

            HashSet<int> dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            for (int i = 1; i <= rangeEnd; i++)
            {
                bool numberIsDivisible = false;

                foreach (var divider in dividers)
                {
                    Predicate<int> isDivisible = n => n % divider == 0;

                    if (isDivisible(i))
                    {
                        numberIsDivisible = true;
                    }
                    else
                    {
                        numberIsDivisible = false;
                        break;
                    }
                }
                if (numberIsDivisible)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
