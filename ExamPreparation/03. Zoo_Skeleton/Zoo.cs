using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;
        public Zoo(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.animals = new List<Animal>();
        }

        public string Name { get; private set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Animal> Animals => this.animals;
        public int Count => this.Animals.Count;

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (this.Capacity == this.Count)
            {
                return "The zoo is full.";
            }
            this.animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species)
        {
            int countOfRemoved = 0;
            while (this.animals.FirstOrDefault(x => x.Species == species) != null)
            {
                var targetAnimal = this.animals.FirstOrDefault(x => x.Species == species);
                this.animals.Remove(targetAnimal);
                countOfRemoved++;
            }
            return countOfRemoved;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> animalByDiet = new List<Animal>();
            foreach (var item in animals)
            {
                if (item.Diet == diet)
                {
                    animalByDiet.Add(item);
                }
            }
            return animalByDiet;
        }
        public Animal GetAnimalByWeight(double weight)
        {
            var targetAnimal = this.animals.FirstOrDefault(x => x.Weight == weight);
            return targetAnimal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int animalCountByLength = 0;
            foreach (var item in this.animals)
            {
                if (item.Length >= minimumLength && item.Length <= maximumLength)
                {
                    animalCountByLength++;
                }
            }
            return $"There are {animalCountByLength} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}
