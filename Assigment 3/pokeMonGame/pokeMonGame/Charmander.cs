using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class Charmander : Pokemon
    {
       
        public Charmander(string name) : base(name)
        {
            this.name = name;
            strength = "Fire";
            weakness = "Water";
 
        }



        public override string battleCry()
        {
            return $"Go {name}!";
        }
    }
}
