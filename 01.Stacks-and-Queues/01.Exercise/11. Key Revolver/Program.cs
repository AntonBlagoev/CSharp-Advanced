using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> locksQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            int intelligenceValue = int.Parse(Console.ReadLine());

            int bulletsCount = 0;

            while (bulletsStack.Any() && locksQueue.Any())
            {
                    int bulletSize = bulletsStack.Pop();
                    int locksSize = locksQueue.Peek();
                    bulletsCount++;

                    if (bulletSize <= locksSize)
                    {
                        locksQueue.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
               
                if (bulletsCount % gunBarrelSize == 0 && bulletsStack.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locksQueue.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
            else
            {
                int moneyEarned = intelligenceValue - (bulletPrice * bulletsCount);
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
