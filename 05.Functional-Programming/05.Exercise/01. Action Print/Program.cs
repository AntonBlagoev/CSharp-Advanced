using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));
            
            string[] inputArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            print(inputArr);

        }

        
    }
}
