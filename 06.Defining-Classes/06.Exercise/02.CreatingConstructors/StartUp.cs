using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("Petar", 20);
            Console.WriteLine($"{person.Name} {person.Age}");
        }
    }

    public class Person
    {
        public Person()
        {
            Name = "No name";
            Age = 1;
        }
        public Person(int age) : this()
        {
            Age = age;
        }
        public Person(string name, int age) : this(age)
        {
            Name = name;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

    }
}
