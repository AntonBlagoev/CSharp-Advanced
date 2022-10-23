using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count => this.Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (this.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            var targetCPU = this.Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (targetCPU != null)
            {
                this.Multiprocessor.Remove(targetCPU);
                return true;
            }
            return false;
        }
        public CPU MostPowerful()
        {
            double highestFrequency = 0.0;
            foreach (var item in this.Multiprocessor)
            {
                if (item.Frequency > highestFrequency)
                {
                    highestFrequency = item.Frequency;
                }
            }
            return this.Multiprocessor.FirstOrDefault(x => x.Frequency == highestFrequency);
        }
        public CPU GetCPU(string brand)
        {
            var targetCPU = this.Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (targetCPU != null)
            {
                return targetCPU;
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");
            foreach (var cpu in this.Multiprocessor)
            {
                sb.AppendLine($"{cpu}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
