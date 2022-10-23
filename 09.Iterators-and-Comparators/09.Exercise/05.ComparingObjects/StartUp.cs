using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> personsList = new List<Person>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                personsList.Add(new Person(name, age, town));
            }
            int equalCount = 0;

            Person personToCompare = personsList[int.Parse(Console.ReadLine()) - 1];

            foreach (var person in personsList)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {personsList.Count - equalCount} {personsList.Count}");
            }
        }
    }
}
