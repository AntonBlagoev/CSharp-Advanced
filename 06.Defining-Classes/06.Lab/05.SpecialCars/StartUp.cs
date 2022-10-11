using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> tireTmpList = new List<string>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                tireTmpList.Add(command);
            }

            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                engines.Add(new Engine(int.Parse(tokens[0]), double.Parse(tokens[1])));
            }

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                int fuelQuantity = int.Parse(tokens[3]);
                int fuelConsumption = int.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                // add tireTmpList to Tire[]
                string[] tmp = tireTmpList[tiresIndex].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var tires = new Tire[tmp.Length / 2]; // or Tire[4]
                int countTires = 0;
                for (int i = 0; i < tmp.Length - 1; i++) // or i < 7
                {
                    tires[countTires] = (new Tire(int.Parse(tmp[i]), double.Parse(tmp[i + 1])));
                    countTires++;
                    i++;
                }
                //

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires));
            }

            var specialCars = cars.Where(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >= 9 && x.Tires.Sum(y => y.Pressure) <= 10).ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.Write(car.WhoAmI());
            }
        }
    }
}




