using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> catalog;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            catalog = new List<Renovator>();
        }

        public string Name { get; private set; }
        public int NeededRenovators { get; private set; }
        public string Project { get; private set; }
        public IReadOnlyCollection<Renovator> Renovators => this.catalog; // !!!
        public int Count => this.Renovators.Count; // !!!
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            else if (this.Count == this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            else
            {
                this.catalog.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }
        public bool RemoveRenovator(string name)
        {
            var renovatorToRemove = this.catalog.FirstOrDefault(x => x.Name == name);
            if (renovatorToRemove != null)
            {
                this.catalog.Remove(renovatorToRemove);
                return true;
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int countOfRemoved = 0;
            while (this.catalog.FirstOrDefault(x => x.Type == type) != null)
            {
                var renovatorToRemove = this.catalog.FirstOrDefault(x => x.Type == type);
                this.catalog.Remove(renovatorToRemove);
                countOfRemoved++;
            }
            return countOfRemoved;
        }
        public  Renovator HireRenovator(string name)
        {
            var targetRenovator = this.catalog.FirstOrDefault(x => x.Name == name);
            if (targetRenovator == null)
            {
                return null;
            }
            targetRenovator.Hired = true;
            return targetRenovator;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> paidRenovators = new List<Renovator>();
            foreach (var item in this.Renovators.Where(x => x.Days >= days))
            {
                paidRenovators.Add(item);
            }
            return paidRenovators;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in catalog.Where(x => x.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();


        }

    }
}
