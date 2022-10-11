using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isEvenCommand = Console.ReadLine() == "even";

            Predicate<int> isEvenNumber = n => n % 2 == 0;

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (isEvenCommand && isEvenNumber(i))
                {
                    Console.Write($"{i} ");
                }
                else if (!(isEvenCommand) && !(isEvenNumber(i)))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
