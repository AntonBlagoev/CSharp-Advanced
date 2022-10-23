using System;

namespace _04.GenericSwapMethodInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                box.Add(int.Parse(Console.ReadLine()));
            }
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int indexOne = int.Parse(commands[0]);
            int indexTwo = int.Parse(commands[1]);

            box.Swap(indexOne, indexTwo);

            Console.WriteLine(box.ToString());
        }
    }
}
