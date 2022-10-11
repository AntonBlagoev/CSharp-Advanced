using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> nestedDict = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!nestedDict.ContainsKey(continent))
                {
                    nestedDict.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!nestedDict[continent].ContainsKey(country))
                {
                    nestedDict[continent].Add(country, new List<string>());
                }

                nestedDict[continent][country].Add(city);
            }

            foreach (var continent in nestedDict)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> ");
                    Console.WriteLine(string.Join(", ", country.Value));
                }
            }
        }
    }
}
