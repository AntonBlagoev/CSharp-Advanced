using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUppercaseLetter = w => char.IsUpper(w[0]);

            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isUppercaseLetter(w))));


            //Predicate<string> isUppercase = w => char.IsUpper(w[0]);
            //Console.WriteLine(string.Join(Environment.NewLine, Array
            //    .FindAll(Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries), isUppercase)));
        }
    }
}
