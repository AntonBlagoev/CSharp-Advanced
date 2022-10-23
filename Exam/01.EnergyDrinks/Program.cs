using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeine = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> drinks = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int sumOfCaffeine = 0;

            while (caffeine.Count != 0 && drinks.Count != 0)
            {
                int currentCaffeine = caffeine.Peek();
                int currentDrink = drinks.Peek();
                int total = currentCaffeine * currentDrink;

                if (sumOfCaffeine + total > 300)
                {
                    caffeine.Pop();
                    drinks.Dequeue();
                    drinks.Enqueue(currentDrink);

                    if (sumOfCaffeine - 30 < 0)
                    {
                        sumOfCaffeine = 0;
                    }
                    else
                    {
                        sumOfCaffeine -= 30;
                    }
                }
                else
                {
                    caffeine.Pop();
                    drinks.Dequeue();
                    sumOfCaffeine += total;
                }
            }

            if (drinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {sumOfCaffeine} mg caffeine.");


        }
    }
}
