using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Stack<int> calories = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> mealCalories = new Dictionary<string, int>();
            mealCalories.Add("salad", 350);
            mealCalories.Add("soup", 490);
            mealCalories.Add("pasta", 680);
            mealCalories.Add("steak", 790);

            int numberOfMeals = 0;
            while (meals.Count > 0 && calories.Count > 0)
            {
                int dailyCalories = calories.Peek();
                int neededCalories = mealCalories[meals.Peek()];

                if (dailyCalories > neededCalories)
                {
                    meals.Dequeue();
                    numberOfMeals++;
                    dailyCalories -= neededCalories;
                    calories.Pop();
                    calories.Push(dailyCalories);
                }
                else if (dailyCalories == neededCalories)
                {
                    meals.Dequeue();
                    numberOfMeals++;
                    calories.Pop();
                }
                else if (dailyCalories < neededCalories)
                {
                   
                    int tmpMealCalories = dailyCalories;
                    calories.Pop();
                    if (calories.Count != 0)
                    {
                        tmpMealCalories += calories.Peek();
                        calories.Pop();
                        calories.Push(tmpMealCalories);
                    }
                    else
                    {
                        meals.Dequeue();
                        numberOfMeals++;
                    }
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.Write($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals} meals.");
                Console.Write($"Meals left: {string.Join(", ", meals)}.");
            }


        }
    }
}
