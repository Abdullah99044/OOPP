using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class Charmander
    {
        public string name;
        public string strength;
        public string weakness;

        public Charmander(string name)
        {
            this.name = name;
            strength = "Fire";
            weakness = "Water";
        }

        public string battleCry()
        {
            return $"Go {name}!";
        }
    }
}
