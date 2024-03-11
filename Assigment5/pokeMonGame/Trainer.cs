using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class Trainer
    {
        private string name;

        private List<PokeBall> belt;

        private const int maxBeltCount = 6;
        public Trainer(string name)
        {

            this.name = name;
            belt = new List<PokeBall>();

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public PokeBall getPokeBallFromBelt(int index)
        {
            return belt[index];
        }
        public  int getBeltCount()
        {
            return belt.Count; 
        }

        public void removeFromBelt(int index)
        {
            belt.RemoveAt(index);

        }

        public void clearBelt()
        {
            belt.Clear();

        }

        public string addPokeballsTotheBelt(string name  )
        {
            try
            {
                //The pokemons are added to the belt in a fixed order = [Charmander , Squirtle , Bulbasaur , Charmander , Squirtle , Bulbasaur]
                if (belt.Count < maxBeltCount)
                {

                    if (belt.Count == 0 || belt.Count == 3)
                    {
                        Charmander charmander = new Charmander(name);
                        belt.Add(new PokeBall(charmander));
                        return $"A Charmander added to the Pokeball successfully ";
                    }

                    if (belt.Count == 1 || belt.Count == 4)
                    {
                        Squirtle squirtle = new Squirtle(name);
                        belt.Add(new PokeBall(squirtle));
                        return $"A Squirtle added to the Pokeball successfully  ";
                    }

                    if (belt.Count == 2 || belt.Count == 5)
                    {
                        Bulbasaur bulbasaur = new Bulbasaur(name);
                        belt.Add(new PokeBall(bulbasaur));
                        return $"Bulbasaur  added to the Pokeball  successfully  ";
                    }


                }

                //Trhow an error when the belt is full

                throw new Exception("Trainer belt is full, You cant add more pokeballs!");
            }

            catch (Exception e)
            {
                return e.ToString();
            }

        }
       
        public string throwPokeball(int index)
        {
            return $"Trainer {name} throw his pokeball : {belt[index].openPokeball()}";
        }

        public string returnPokeball(int index)
        {
            return $"Trainer {name} return his pokeball  back : {belt[index].closePokeball()}";
        }
    }
}
