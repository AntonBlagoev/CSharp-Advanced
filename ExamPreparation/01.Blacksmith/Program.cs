using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> carbon = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<string, int> swords = new Dictionary<string, int>();
            swords.Add("Gladius", 0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0);
            swords.Add("Broadsword", 0);


            while (steel.Count != 0 && carbon.Count != 0)
            {
                int currentSteel = steel.Peek();
                int currentCarbon = carbon.Peek();
                int sum = currentSteel + currentCarbon;

                if (sum == 70)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    swords["Gladius"]++;
                }

                else if (sum == 80)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    swords["Shamshir"]++;
                }
                else if (sum == 90)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    swords["Katana"]++;
                }
                else if (sum == 110)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    swords["Sabre"]++;
                }
                else if (sum == 150)
                {
                    steel.Dequeue();
                    carbon.Pop();
                    swords["Broadsword"]++;
                }
                else
                {
                    steel.Dequeue();
                    carbon.Pop();
                    carbon.Push(currentCarbon + 5);
                }
            }

            int totalNumberOfSwords = swords.Sum(x => x.Value);

            if (totalNumberOfSwords > 0)
            {
                Console.WriteLine($"You have forged {totalNumberOfSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            foreach (var sword in swords.Where(x => x.Value >0).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
