using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> stones = new List<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            
            Lake lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));

        }
    }
}
