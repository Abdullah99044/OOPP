using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class PokeBall
    {

        public Charmander charmander;

        public PokeBall(Charmander charmander)
        {

            this.charmander = charmander;

        }


        public bool isFull()
        {
            if (charmander == null) 
                return false;

            return true;
        }

        public string openPokeball()
        {
            if (!isFull())
                return "Pokeball is empty";

            return $"{charmander.name} is released : {charmander.battleCry()}";
        }

        public string closePokeball()
        {
            if (!isFull())
                return "Pokeball is empty";

            return $"{charmander.name} is back to the pokeball";
        }

    }
}
