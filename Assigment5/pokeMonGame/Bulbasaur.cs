using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class Bulbasaur : Pokemon
    {

        public Bulbasaur(string name) : base(name)
        {
            this.name = name;
            strength = PokemonStrength.Leaf;
            weakness = PokemonStrength.Fire;
 
        }
        public override string battleCry()
        {
            return $"Go {Name}!";
        }
    }
}
