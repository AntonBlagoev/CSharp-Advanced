using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> freshness = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", 0); // 150
            dishes.Add("Green salad", 0); // 250
            dishes.Add("Chocolate cake", 0); // 300
            dishes.Add("Lobster", 0); // 400

            while (ingredients.Count != 0 && freshness.Count != 0)
            {
                int currentIngredients = ingredients.Peek();
                int currentFreshness = freshness.Peek();
                int total = currentIngredients * currentFreshness;

                if (total == 150)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (total == 250)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (total == 300)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (total == 400)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (currentIngredients == 0)
                {
                    ingredients.Dequeue();
                }
                else
                {
                    ingredients.Dequeue();
                    freshness.Pop();
                    ingredients.Enqueue(currentIngredients + 5);
                }

            }
            Dictionary<string, int> isNotSuccessful = new Dictionary<string, int>();
            foreach (var item in dishes)
            {
                if (item.Value == 0)
                {
                    isNotSuccessful.Add(item.Key, item.Value);
                }
            }
            if (isNotSuccessful.Count == 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                int ingridientsSum = ingredients.Sum(x => x);
                Console.WriteLine($"Ingredients left: {ingridientsSum}");
            }

            foreach (var dish in dishes.OrderBy(x => x.Key).Where(x => x.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }

        }
    }
}
