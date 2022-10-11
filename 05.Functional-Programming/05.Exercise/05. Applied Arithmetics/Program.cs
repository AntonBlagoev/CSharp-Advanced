using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int> addFunc = x => x + 1;
            Func<int, int> multiplyFunc = x => x * 2;
            Func<int, int> subtractFunc = x => x - 1;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        Operations(numbers, addFunc);
                        break;
                    case "multiply":
                        Operations(numbers, multiplyFunc);
                        break;
                    case "subtract":
                        Operations(numbers, subtractFunc);
                        break;
                    case "print":
                        Console.WriteLine(string.Join(' ', numbers));
                        break;
                    default:
                        break;
                }
            }
        }

        private static void Operations(int[] numbers, Func<int, int> operation)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = operation(numbers[i]);
            }
        }
    }
}
