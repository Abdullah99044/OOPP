using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class Trainer
    {
        public string name;

        public List<PokeBall> belt;
        public Trainer(string name)
        {

            this.name = name;
            belt = new List<PokeBall>();

        }

        public string addPokeballsTotheBelt(string name)
        {
            if (belt.Count <= 6)
            {
                Charmander charmander = new Charmander(name);
                PokeBall pokeBall = new PokeBall(charmander);
                belt.Add(pokeBall);
                return "Pokeball added successfully";
            }

            return "Trainer belt is full";
        }

        public string throwPokeball(int index)
        {
            return $"Trainer {name} throw his pokeball {belt[index].openPokeball()}";
        }

        public string returnPokeball(int index)
        {
            return $"Trainer {name} return his pokeball  back : {belt[index].closePokeball()}";
        }
    }
}
