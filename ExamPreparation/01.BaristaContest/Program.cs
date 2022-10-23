using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BaristaContest
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>(Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray());
            Stack<int> milk = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
           

            Dictionary<string, int> amounts = new Dictionary<string, int>();
            amounts.Add("Cortado", 0);
            amounts.Add("Espresso", 0);
            amounts.Add("Capuccino", 0);
            amounts.Add("Americano", 0);
            amounts.Add("Latte", 0);



            while (coffee.Count != 0 && milk.Count != 0)
            {
                int currentCoffee = coffee.Peek();
                int currentMilk = milk.Peek();

                if (currentCoffee + currentMilk == 50)
                {
                    amounts["Cortado"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }

                else if (currentCoffee + currentMilk == 75)
                {
                    amounts["Espresso"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else if (currentCoffee + currentMilk == 100)
                {
                    amounts["Capuccino"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else if (currentCoffee + currentMilk == 150)
                {
                    amounts["Americano"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else if (currentCoffee + currentMilk == 200)
                {
                    amounts["Latte"]++;
                    coffee.Dequeue();
                    milk.Pop();
                }

                else
                {
                    coffee.Dequeue();
                    milk.Pop();
                    milk.Push(currentMilk - 5);
                }

            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }
            if (milk.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }


            foreach (var item in amounts.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (item.Value != 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

        }
    }
}
