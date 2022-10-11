using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                var engine = new Engine(int.Parse(tokens[1]), int.Parse(tokens[2]));
                var cargo = new Cargo(int.Parse(tokens[3]), tokens[4]);
                var tires = new Tires[4];
                int countTires = 0;
                for (int j = 5; j < 12; j++)
                {
                    tires[countTires] = new Tires(double.Parse(tokens[j]), int.Parse(tokens[j + 1]));
                    countTires++;
                    j++;
                }

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "fragile" && car.Tires.Any(x => x.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
