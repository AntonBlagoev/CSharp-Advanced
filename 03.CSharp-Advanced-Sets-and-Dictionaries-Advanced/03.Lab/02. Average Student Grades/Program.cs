using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputStudent = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string student = inputStudent[0];
                decimal grade = decimal.Parse(inputStudent[1]);

                if (!studentGrades.ContainsKey(student))
                {
                    studentGrades.Add(student, new List<decimal>());
                }
                studentGrades[student].Add(grade);
            }

            foreach (var student in studentGrades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (decimal grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
