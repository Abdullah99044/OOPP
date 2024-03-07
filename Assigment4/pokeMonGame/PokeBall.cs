using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class PokeBall
    {

        public Pokemon pokemon;

        public PokeBall(Pokemon pokemon)
        {

            this.pokemon = pokemon;

        }


        public bool isFull()
        {
            if (pokemon == null) 
                return false;

            return true;
        }

        public string openPokeball()
        {
            if (!isFull())
                return "Pokeball is empty";

            return $"Pokeball is open  {pokemon.battleCry()} ";
        }

        public string closePokeball()
        {
            if (!isFull())
                return "Pokeball is empty";

            return $"{pokemon.name} is back to the pokeball";
        }

    }
}
