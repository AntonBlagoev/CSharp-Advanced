using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> userNamesSet = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                userNamesSet.Add(input);
            }
            foreach (var user in userNamesSet)
            {
                Console.WriteLine(user);
            }
        }
    }
}
