using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Data = new List<Ski>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Ski> Data { get; set; }
        public int Count => this.Data.Count;

        public void Add(Ski ski)
        {
            if (this.Count < this.Capacity)
            {
                this.Data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var target = this.Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (target != null)
            {
                this.Data.Remove(target);
                return true;
            }
            return false;
        }
        public Ski GetNewestSki()
        {
            if (this.Count > 0)
            {
                int maxYear = 0;
                foreach (var item in this.Data)
                {
                    if (item.Year > maxYear)
                    {
                        maxYear = item.Year;
                    }
                }
                var target = this.Data.FirstOrDefault(x => x.Year == maxYear);
                return target;
            }
            return null;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            var target = this.Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (target != null)
            {
                return target;
            }
            return null;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {this.Name}:");
            foreach (var item in this.Data)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
