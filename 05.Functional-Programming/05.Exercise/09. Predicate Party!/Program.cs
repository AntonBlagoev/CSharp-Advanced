using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
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

                Predicate<string> isStartWith = x => x.StartsWith(tokens[2]);
                Predicate<string> isEndtWith = x => x.EndsWith(tokens[2]);
                Predicate<string> isGivenLenght = x => x.Length == int.Parse(tokens[2]);

                switch (tokens[0])
                {
                    case "Double":
                        if (tokens[1] == "StartsWith")
                        {
                            DoublePeople(people, isStartWith);
                        }
                        else if (tokens[1] == "EndsWith")
                        {
                            DoublePeople(people, isEndtWith);
                        }
                        else if (tokens[1] == "Length")
                        {
                            DoublePeople(people, isGivenLenght);
                        }
                        break;

                    case "Remove":
                        if (tokens[1] == "StartsWith")
                        {
                            RemovePeople(people, isStartWith);
                        }
                        else if (tokens[1] == "EndsWith")
                        {
                            RemovePeople(people, isEndtWith);
                        }
                        else if (tokens[1] == "Length")
                        {
                            RemovePeople(people, isGivenLenght);
                        }
                        break;

                    default:
                        break;
                }
            }
            if (people.Count > 0)
            {
                Console.Write(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void DoublePeople(List<string> people, Predicate<string> operation)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (operation(people[i]))
                {
                    people.Insert(i, people[i]);
                    i++;
                }
            }
        }
        private static void RemovePeople(List<string> people, Predicate<string> operation)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (operation(people[i]))
                {
                    people.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
