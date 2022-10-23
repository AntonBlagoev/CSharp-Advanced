using System;
using System.Collections.Generic;

namespace _03.GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                box.Add(Console.ReadLine());
            }
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int indexOne = int.Parse(commands[0]);
            int indexTwo = int.Parse(commands[1]);

            box.Swap(indexOne, indexTwo);

            Console.WriteLine(box.ToString());
        }
    }
}
