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
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int power = int.Parse(tokens[1]);

                Engine engine = new Engine(model, power);

                if (tokens.Length == 4)
                {
                    engine.Displacement = int.Parse(tokens[2]);
                    engine.Efficiency = tokens[3];

                }
                else if (tokens.Length == 3)
                {

                    if (Char.IsLetter(tokens[2][0]))
                    {
                        engine.Efficiency = tokens[2];
                    }
                    else
                    {
                        engine.Displacement = int.Parse(tokens[2]);
                    }
                }

                engines.Add(engine);
            }

            n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                Engine engine = engines.Find(x => x.Model == tokens[1]);

                Car car = new Car(model, engine);

                if (tokens.Length == 4)
                {
                    car.Weight = int.Parse(tokens[2]);
                    car.Color = tokens[3];
                }
                else if (tokens.Length == 3)
                {
                    if (Char.IsLetter(tokens[2][0]))
                    {
                        car.Color = tokens[2];
                    }
                    else
                    {
                        car.Weight = int.Parse(tokens[2]);
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
