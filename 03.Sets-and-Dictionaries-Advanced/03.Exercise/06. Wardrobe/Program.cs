using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 1; j < tokens.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(tokens[j]))
                    {
                        wardrobe[color].Add(tokens[j], 0);
                    }
                    wardrobe[color][tokens[j]]++;
                }

                //string[] input = Console.ReadLine().Split(" -> ");
                //string color = input[0];
                //string[] clothing = input[1].Split(',');

                //if (!wardrobe.ContainsKey(color))
                //{
                //    wardrobe.Add(color, new Dictionary<string, int>());
                //}
                //foreach (var item in clothing)
                //{
                //    if (!wardrobe[color].ContainsKey(item))
                //    {
                //        wardrobe[color].Add(item, 0);
                //    }
                //    wardrobe[color][item]++;
                //}
            }

            string[] searchedClothing = Console.ReadLine().Split();
            string searchedColor = searchedClothing[0];
            string searchedItem = searchedClothing[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var dress in item.Value)
                {
                    string printItem = $"* {dress.Key} - {dress.Value}";

                    if (item.Key == searchedColor && dress.Key == searchedItem)
                    {
                        printItem += $" (found!)";
                    }
                    Console.WriteLine(printItem);
                }
            }

        }
    }
}
