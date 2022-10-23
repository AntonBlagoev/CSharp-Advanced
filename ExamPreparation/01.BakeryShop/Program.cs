using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray());
            Stack<double> flour = new Stack<double>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray());

            Dictionary<string, int> productsCount = new Dictionary<string, int>();
            productsCount.Add("Croissant", 0);
            productsCount.Add("Muffin", 0);
            productsCount.Add("Baguette", 0);
            productsCount.Add("Bagel", 0);


            while (water.Count != 0 && flour.Count != 0)
            {
                double currentWater = water.Peek();
                double currentFlour = flour.Peek();
                double currentWaterPercent = (currentWater / (currentWater + currentFlour)) * 100;

                if (currentWaterPercent == 50)
                {
                    water.Dequeue();
                    flour.Pop();
                    productsCount["Croissant"]++;
                }
                else if (currentWaterPercent == 40)
                {
                    water.Dequeue();
                    flour.Pop();
                    productsCount["Muffin"]++;
                }
                else if (currentWaterPercent == 30)
                {
                    water.Dequeue();
                    flour.Pop();
                    productsCount["Baguette"]++;
                }
                else if (currentWaterPercent == 20)
                {
                    water.Dequeue();
                    flour.Pop();
                    productsCount["Bagel"]++;
                }
                else
                {
                    water.Dequeue();
                    flour.Pop();
                    productsCount["Croissant"]++;

                    currentFlour -= currentWater;
                    flour.Push(currentFlour);
                }


            }
            foreach (var product in productsCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
            if (water.Count != 0)
            {
                Console.WriteLine($"Water left: {string.Join(", " , water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flour.Count != 0)
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
