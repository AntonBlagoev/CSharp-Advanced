using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackOfClothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int capacityOfRack = int.Parse(Console.ReadLine());

            Stack<int> tmpRack = new Stack<int>();
            int countOfRacks = 0;

            while (stackOfClothes.Count > 0)
            {
                int checkSum = tmpRack.Sum() + stackOfClothes.Peek();
                if (checkSum > capacityOfRack)
                {
                    tmpRack.Clear();
                    countOfRacks++;
                }
                else if (stackOfClothes.Count == 1)
                {
                    stackOfClothes.Pop();
                    countOfRacks++;
                }
                else
                {
                    tmpRack.Push(stackOfClothes.Pop());
                }

            }
            Console.WriteLine(countOfRacks);
        }
    }
}
