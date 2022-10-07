using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, string> addVAT = p => (p * 1.2).ToString("F2");

            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVAT)));


            //Func<double, double> addVAT = p => p * 1.2;

            //double[] numbers = Console.ReadLine()
            //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => double.Parse(x))
            //    .ToArray();

            //foreach (var item in numbers)
            //{
            //    Console.WriteLine($"{addVAT(item):f2}");
            //}
        }
    }
}
