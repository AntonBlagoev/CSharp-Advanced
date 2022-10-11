using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Trainer
    {
        public Trainer(string name, List<Pokemon> pokemonsCollection)
        {
            Name = name;
            PokemonsCollection = pokemonsCollection;
        }
        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> PokemonsCollection { get; set; }

        public void CheckPokemon(string element)
        {
            if (this.PokemonsCollection.Any(p => p.Element == element))
            {
                Badges++;
            }
            else
            {
                for (int i = 0; i < this.PokemonsCollection.Count; i++)
                {
                    Pokemon currentPokemon = this.PokemonsCollection[i];

                    currentPokemon.Health -= 10;

                    if (currentPokemon.Health <= 0)
                    {
                        this.PokemonsCollection.Remove(currentPokemon);
                    }
                }
            }
        }
    }
}
