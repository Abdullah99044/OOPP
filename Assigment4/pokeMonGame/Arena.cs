using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class Arena
    {
        
        public Trainer trainer1;
        public Trainer trainer2;

        //Static fields to track trainers stats
        public static int tottalRounds;
        public static int tottalBattles;

        public Battle battle;

         public Arena(Trainer trainer1 , Trainer trainer2)
         {
            this.trainer1 = trainer1;
            this.trainer2 = trainer2;
            this.battle = new Battle(trainer1 , trainer2);
         }

        public void battleArena()
        {
            

            Console.WriteLine("");
            Console.WriteLine("************************************************");
            Console.WriteLine("");

            //Clear the trainers belt every time the battle starts
            trainer1.belt.Clear();
            trainer2.belt.Clear();

            //Check if there are more than 6 pokeballs in the trainers belt
            //If there are less than 6 pokeballs then the player can add  pokeballs to the trainers belt

            if (trainer1.belt.Count < 6)
            {
                for (int i = 0; i != 6; i++)
                {
                    //The player gives every pokemone a nick name
                    Console.WriteLine($"Give Pokemone {i + 1} of Trainer {trainer1.name} a name : ");
                    string charmanderName = Console.ReadLine();
                    Console.WriteLine(trainer1.addPokeballsTotheBelt(charmanderName, i));
                   
                }
            }

            Console.WriteLine("");
            Console.WriteLine("************************************************");
            Console.WriteLine("");

            if (trainer2.belt.Count < 6)
            {
                for (int i = 0; i != 6; i++)
                {
                    //The player gives every pokemone a nick name
                    Console.WriteLine($"Give Pokemone {i + 1} of Trainer {trainer2.name} a name : ");
                    string charmanderName = Console.ReadLine();
                    Console.WriteLine(trainer2.addPokeballsTotheBelt(charmanderName, i));
                }
            }

            Console.WriteLine("");
            Console.WriteLine("************************************************");
            Console.WriteLine("");

            //This method calculate the outcoms every round
            battle.round();

            //Store the rounds and the battle stats
            tottalRounds = tottalRounds + battle.returnTottalRounds();
            tottalBattles++;

            Console.WriteLine(printResults());

        }

        public static string printResults()
        {

            string result = "";

            result +=  "\n ";
            result +=  $"\n Tottal rounds played  :  {tottalRounds}";
            result +=  $"\n Tottal battles played : {tottalBattles}";
            result +=  "\n ";
            result +=  "\n************************************************";
            result +=  "\n ";

            return result ;

        }
    }
}
