using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public int Count => this.Drones.Count(d => d.Available == true);

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) ||
                string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (this.Drones.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            int count = this.Drones.RemoveAll(d => d.Name == name);
            return count > 0;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = this.Drones.RemoveAll(d => d.Brand == brand);
            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = this.Drones.FirstOrDefault(d => d.Name == name);
            if (drone == null)
            {
                return null;
            }
            drone.Available = false;
            return drone;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> matchingDrones =
                this.Drones.Where(d => d.Range >= range).ToList();
            foreach (var d in matchingDrones)
            {
                d.Available = false;
            }
            return matchingDrones;

            //List<Drone> flyDrones = new List<Drone>();
            //foreach (var drone in this.Drones.Where(x => x.Range >= range))
            //{
            //    flyDrones.Add(drone);
            //    drone.Available = false;
            //}
            //return flyDrones;
        }

        public string Report()
        {
            var dronesAvailable = this.Drones.Where(d => d.Available == true);
            return
                $"Drones available at {this.Name}:" + Environment.NewLine +
                string.Join(Environment.NewLine, dronesAvailable);

            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Drones available at {Name}:");
            //foreach (var drone in this.Drones.Where(x => x.Available == true))
            //{
            //    sb.AppendLine($"{drone}");
            //}

            //return sb.ToString().TrimEnd();
        }
    }
}
