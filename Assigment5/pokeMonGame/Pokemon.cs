using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{

    public enum PokemonStrength
    {
        Fire,
        Water,
        Leaf
    }
    public abstract class Pokemon
    {
        protected string name;
        protected PokemonStrength strength;
        protected PokemonStrength weakness; 
        public Pokemon(string name)
        {

        }

        public string Name{ get { return name; }  }

        public PokemonStrength Strength
        {
            get { return strength; }
        }

        public PokemonStrength Weakness
        {
            get { return weakness; }
        }

        public abstract string battleCry();
         
    }
}
