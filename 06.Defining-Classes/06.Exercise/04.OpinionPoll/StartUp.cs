using System;
using System.Collections.Generic;
using System.Linq;


namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                persons.Add(new Person(name, age));
            }

            var sortedPersons = persons.Where(x => x.Age > 30).OrderBy(x => x.Name);
            foreach (var person in sortedPersons)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }


        }
    }
    
    
}
