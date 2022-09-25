using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            Queue<int> ordersQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(ordersQueue.Max());

            while (ordersQueue.Count > 0)
            {
                int currentOrder = ordersQueue.Dequeue();
                if (foodQuantity < currentOrder)
                {
                    ordersQueue.Enqueue(currentOrder);
                    for (int i = 0; i < ordersQueue.Count - 1; i++)
                    {
                        int tmp = ordersQueue.Dequeue();
                        ordersQueue.Enqueue(tmp);
                    }
                    break;
                }
                foodQuantity -= currentOrder;
            }

            if (ordersQueue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
