using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (this.Participants.Count == 0)
            {
                this.Participants.Add(car);
                return;
            }
            var targetCar = this.Participants.FirstOrDefault(x => x.LicensePlate != car.LicensePlate && car.HorsePower <= MaxHorsePower);
            if (targetCar != null && this.Capacity > this.Count)
            {
                this.Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            var targetCar = this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (targetCar != null)
            {
                this.Participants.Remove(targetCar);
                return true;
            }
            return false;
        }
        public Car FindParticipant(string licensePlate)
        {
            Car targetCar = this.Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (targetCar != null)
            {
                return targetCar;
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            if (this.Participants.Count > 0)
            {
                this.Participants.OrderByDescending(x => x.HorsePower);
                return this.Participants[0];
            }
            return null;
        }
        public string Report()
        {
            return
                $"Race: {Name} - Type: {Type} (Laps: {Laps}){Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, Participants)}";

        }

    }
}
