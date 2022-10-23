using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootbox = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> secondLootbox = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int claimedItemsSum = 0;


            while (firstLootbox.Count != 0 && secondLootbox.Count != 0)
            {
                int currFirstLootboxItem = firstLootbox.Peek();
                int currSecondLootboxItem = secondLootbox.Peek();
                int sum = currFirstLootboxItem + currSecondLootboxItem;

                if (sum % 2 == 0)
                {
                    claimedItemsSum += sum;
                    firstLootbox.Dequeue();
                    secondLootbox.Pop();
                }
                else
                {
                    secondLootbox.Pop();
                    firstLootbox.Enqueue(currSecondLootboxItem);
                }
            }
            if (firstLootbox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }

        }
    }
}
