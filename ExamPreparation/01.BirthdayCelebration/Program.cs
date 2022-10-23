using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> guests = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray()
                .Reverse());

            Stack<int> plates = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int wastedGramsOfFood = 0;

            while (guests.Count != 0 && plates.Count != 0)
            {
                int currentGuest = guests.Peek();
                int currentPlate = plates.Peek();

                if (currentGuest <= currentPlate)
                {
                    guests.Pop();
                    plates.Pop();
                    wastedGramsOfFood += (currentPlate - currentGuest);
                }
                else
                {
                    guests.Pop();
                    guests.Push(currentGuest - currentPlate);
                    plates.Pop();
                }
            }
            if (guests.Count == 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
            }
            else if (plates.Count == 0)
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedGramsOfFood}");

        }
    }
}
