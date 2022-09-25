using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songsQueue = new Queue<string>(Console.ReadLine().Split(", "));

            while (songsQueue.Count > 0)
            {
                string[] commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;

                    case "Add":
                        string song = string.Join(" ", commands.Skip(1)); // !!!
                        if (!songsQueue.Contains(song))
                        {
                            songsQueue.Enqueue(song);
                            continue;
                        }
                        Console.WriteLine($"{song} is already contained!");
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ", songsQueue));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
