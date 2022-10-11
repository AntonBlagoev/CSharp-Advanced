using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainersList = new List<Trainer>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Trainer trainer = trainersList.SingleOrDefault(x => x.Name == trainerName);

                if (trainer == null)
                {
                    trainersList.Add(new Trainer(trainerName, new List<Pokemon>() { new Pokemon(pokemonName, pokemonElement, pokemonHealth) }));
                }
                else
                {
                    trainer.PokemonsCollection.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }

            }
            command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainersList)
                {
                    trainer.CheckPokemon(command);
                }
            }

            foreach (var trainer in trainersList.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.PokemonsCollection.Count}");
            }
        }
    }
}
