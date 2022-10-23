using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            fish = new List<Fish>();
        }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Fish> Fish => this.fish;
        public int Count => this.Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if (this.Capacity == this.Count)
            {
                return "Fishing net is full.";
            }
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            var targetFish = this.fish.FirstOrDefault(x => x.Weight == weight);
            if (targetFish == null)
            {
                return false;
            }
            this.fish.Remove(targetFish);
            return true;
        }
        public Fish GetFish(string fishType)
        {
            var targetFish = this.fish.FirstOrDefault(x => x.FishType == fishType);
            if (targetFish == null)
            {
                return null;
            }
            return targetFish;
        }
        public Fish GetBiggestFish()
        {
            Fish biggestFish = null;
            double biggestLenght = 0.0;
            foreach (var fish in this.Fish)
            {
                if (fish.Length > biggestLenght)
                {
                    biggestLenght = fish.Length;
                    biggestFish = fish;
                }

            }
            return biggestFish;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in this.fish.OrderByDescending(x => x.Length))
            {
                sb.AppendLine($"{fish}");
            }


            return sb.ToString().TrimEnd();
        }



    }
}
