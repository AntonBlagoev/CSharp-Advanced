using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPumps = int.Parse(Console.ReadLine());

            Queue<PetrolPump> myQueue = new Queue<PetrolPump>();

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] inputPump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int amountOfPetrol = inputPump[0];
                int distance = inputPump[1];
                myQueue.Enqueue(new PetrolPump(amountOfPetrol, distance));
            }

            int smallestIndex = 0;
            bool isCompleteTour = false;


            for (int i = 0; i < numberOfPumps; i++)
            {
                bool isTankNotEmpty = true;
                int totalAmountOfPetrol = 0;
                int totalDistance = 0;

                for (int j = 0; j < numberOfPumps; j++)
                {
                    totalAmountOfPetrol += myQueue.Peek().AmountOfPetrol;
                    totalDistance += myQueue.Peek().Distance;

                    if (totalAmountOfPetrol < totalDistance)
                    {
                        isTankNotEmpty = false;
                    }

                    myQueue.Enqueue(new PetrolPump(myQueue.Peek().AmountOfPetrol, myQueue.Peek().Distance));
                    myQueue.Dequeue();
                }

                if (isTankNotEmpty)
                {
                    smallestIndex = i;
                    isCompleteTour = true;
                    break;
                }

                myQueue.Enqueue(new PetrolPump(myQueue.Peek().AmountOfPetrol, myQueue.Peek().Distance));
                myQueue.Dequeue();
            }

            if (isCompleteTour)
            {
                Console.WriteLine(smallestIndex);
            }
            else
            {
                Console.WriteLine("eeee");
            }

        }
    }

    class PetrolPump
    {
        public int AmountOfPetrol { get; set; }
        public int Distance { get; set; }
        public PetrolPump(int amountOfPetrol, int distance)
        {
            AmountOfPetrol = amountOfPetrol;
            Distance = distance;
        }
    }
}
