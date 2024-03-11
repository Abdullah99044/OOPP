using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class Squirtle : Pokemon
    {

        public Squirtle(string name) : base(name)
        {
            this.name = name;
            strength = PokemonStrength.Water; 
            weakness = PokemonStrength.Leaf;
        }

         public override string battleCry()
        {
            return $"Go {Name}!";
        }
    }
}
