using System;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int namesLenght = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isCorrectLenght = x => x.Length <= namesLenght;

            foreach (var name in names)
            {
                if (isCorrectLenght(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
