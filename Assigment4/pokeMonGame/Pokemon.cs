using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public abstract class Pokemon
    {
        public string name;
        public string strength;
        public string weakness;

        public Pokemon(string name)
        {
            
        }

        public abstract string battleCry();
         
    }
}
