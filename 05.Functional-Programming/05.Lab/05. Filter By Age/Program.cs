using System;
using System.Collections.Generic;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople(int.Parse(Console.ReadLine()));

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = CreateFilter(condition, age);
            Action<Person> printer = CreatePrinter(format);
            PrintFilteredPeople(people, filter, printer);
        }

        private static List<Person> ReadPeople(int n)
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                people.Add(new Person(input[0], int.Parse(input[1])));
            }
            return people;
        }
        private static Func<Person, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x.Age < age;
            }
            else
            {
                return x => x.Age >= age;
            }
        }
        private static Action<Person> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Name}");
                case "age":
                    return person => Console.WriteLine($"{person.Age}");
                case "name age":
                    return person => Console.WriteLine($"{person.Name} - {person.Age}");
                case "age name":
                    return person => Console.WriteLine($"{person.Age} - {person.Name}");
                default:
                    throw new ArgumentException(format);
            }
        }
        private static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            foreach (var item in people)
            {
                if (filter(item))
                {
                    printer(item);
                }
            }
        }

    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
