using System;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string, string[]> print = (title, names) =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };

            string[] input = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            print("Sir", input);
        }
    }
}
