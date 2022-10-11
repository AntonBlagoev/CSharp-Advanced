using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party___GoShow_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "Party!")
            {
                string[] tokens = commands.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetPredicate(filter, value));
                }
                else if (action == "Double")
                {
                    List<string> peopleToDuble = people.FindAll(GetPredicate(filter, value));
                    int index = people.FindIndex(GetPredicate(filter, value)); // if not found, return -1
                    if (index >= 0)
                    {
                        people.InsertRange(index, peopleToDuble);
                    }
                }
            }
            if (people.Count > 0)
            {
                Console.Write($"{ string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return x => x.StartsWith(value);
                case "EndsWith":
                    return x => x.EndsWith(value);
                case "Length":
                    return x => x.Length == int.Parse(value);
                default:
                    return default(Predicate<string>); // or NULL
            }
        }
    }
}
