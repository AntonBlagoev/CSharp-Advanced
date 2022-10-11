using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divider = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = n => n % divider == 0;

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (!(isDivisible(numbers[i])))
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
        }
    }
}
