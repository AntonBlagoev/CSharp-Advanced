using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            ListyIterator<string> myList = new ListyIterator<string>(items);

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(myList.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(myList.HasNext());
                }
                else if (command == "Print")
                {
                    try
                    {
                        myList.Print();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }

            }
        }
    }
}
