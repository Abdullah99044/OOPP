using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pokeMonGame
{
    public class Battle
    {

        private Trainer trainer1;
        private Trainer trainer2;
        private int tottalRounds;
        public Battle(Trainer trainer1, Trainer trainer2)
        {

            this.trainer1 = trainer1;
            this.trainer2 = trainer2;

        }

        public void round()
        {

            int rounds = 0;

            //Pick random numbers for every pokeball
            int rnd1 = pickRandomIndex(trainer1);


            int rnd2 = pickRandomIndex(trainer2);

            //These varuables stores the winner of every round
            int previousWinnerPokemon = default;
            Trainer previousWinnerTrainer = null;

            do
            {

                Console.WriteLine("Press a key to start the round : ");
                Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine($"Round -------{rounds}-------");
                Console.WriteLine("");

                //Pick random pokeballs
                PokeBall pokeBall1 = trainer1.getPokeBallFromBelt(rnd1);
                PokeBall pokeBall2 = trainer2.getPokeBallFromBelt(rnd2);

               

                Console.WriteLine(trainer1.throwPokeball(rnd1));
                Console.WriteLine(trainer2.throwPokeball(rnd2));
                

                var pokemone1 = pokeBall1.Pokemon;
                var pokemone2 = pokeBall2.Pokemon;


                //Calaculate the outcome
                if (pokemone1.Strength.ToString() == pokemone2.Weakness.ToString())
                {
                    printOutcome(pokeBall1.Pokemon.Name, trainer2, rnd2);
                    previousWinnerPokemon = rnd1;
                    previousWinnerTrainer = trainer1;

                    //The winner stays in the battle while the loser removed
                    trainer2.removeFromBelt(rnd2);
                    rnd2 = pickRandomIndex(trainer2);
                }
                else if (pokemone2.Strength.ToString() == pokemone1.Weakness.ToString())
                {
                    printOutcome(pokeBall2.Pokemon.Name, trainer1, rnd1);
                    previousWinnerPokemon = rnd2;
                    previousWinnerTrainer = trainer2;

                    //The winner stays in the battle while the loser removed
                    trainer1.removeFromBelt(rnd1);
                    rnd1 = pickRandomIndex(trainer1);
                }
                else if (pokemone2.Strength.ToString() == pokemone1.Strength.ToString())
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Draw!");


                    //If the draw was in the first round, both pokemones will return back to the pokeballs
                    bool isFirstRound = previousWinnerTrainer == null || previousWinnerPokemon == default;

                    if (rounds == 0 || isFirstRound)
                    {
                        printDraw(rnd1, rnd2);

                        rnd1 = pickRandomIndex(trainer1);
                        rnd2 = pickRandomIndex(trainer2);
                    }
                    else
                    {

                        //If the draw was not in the first round, the previous winner will return to his pokeball
                        Console.WriteLine("");
                        Console.WriteLine(previousWinnerTrainer.returnPokeball(previousWinnerPokemon));
                        Console.WriteLine("");

                        previousWinnerTrainer.removeFromBelt(previousWinnerPokemon);

                        //The previous winner will pick new pokeball

                        if (previousWinnerTrainer.Name == trainer1.Name)
                            rnd1 = pickRandomIndex(trainer1);
                        else if (previousWinnerTrainer.Name == trainer2.Name)
                            rnd2 = pickRandomIndex(trainer2);

                        previousWinnerTrainer = null;
                        previousWinnerPokemon = default;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine($"{trainer1.Name} has {trainer1.getBeltCount()} pokeballs left in his belt");
                Console.WriteLine($"{trainer2.Name} has {trainer2.getBeltCount()} pokeballs left in his belt");

                //Battle outcome :
                if (trainer1.getBeltCount() == 0 && trainer2.getBeltCount() == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Battle result is draw!");
                    break;
                }
                else if (trainer2.getBeltCount() == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"{trainer1.Name} won the battle!");
                }
                else if (trainer1.getBeltCount() == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"{trainer2.Name} won the battle!");
                }

                // Avoiding an infinite loop when the last unused Pokemon of trainer1 has the same strength as the last unused Pokemon of trainer2
                // Which cause an infinite loop because there will be no winner
                if (trainer1.getBeltCount() == 1 && trainer2.getBeltCount() == 1)
                {
                    if (pokeBall1.Pokemon.Strength.ToString() == pokeBall2.Pokemon.Strength.ToString())
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Battle result is draw!");
                        break;
                    }
                }

                // Avoiding an infinite loop when the last two unused Pokemons of a trainer  have the same strength as the last unused Pokemons of the other trainer
                // Which cause an infinite loop because there will be no winner

                if ((trainer1.getBeltCount() == 2 && trainer2.getBeltCount() == 2) ||
                    (trainer1.getBeltCount() == 1 && trainer2.getBeltCount() == 2) ||
                    (trainer1.getBeltCount() == 2 && trainer2.getBeltCount() == 1))
                {
                    PokeBall trainer1Pokeball1 = trainer1.getPokeBallFromBelt(0);
                    PokeBall trainer1Pokeball2 = trainer1.getBeltCount() == 2 ? trainer1.getPokeBallFromBelt(1) : null;

                    PokeBall trainer2Pokeball1 = trainer2.getPokeBallFromBelt(0);
                    PokeBall trainer2Pokeball2 = trainer2.getBeltCount() == 2 ? trainer2.getPokeBallFromBelt(1) : null;

                    if ((trainer1Pokeball1 == trainer1Pokeball2 || trainer2Pokeball1 == trainer2Pokeball2) &&
                        (trainer1Pokeball1 == trainer2Pokeball1 || trainer1Pokeball1 == trainer2Pokeball2))
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Battle result is draw! 404");
                        break;
                    }
                }


                rounds++;

            }
            while (trainer1.getBeltCount() > 0 && trainer2.getBeltCount() > 0);

            this.tottalRounds = rounds;
        }
        

        //Generate a random number that can be used as index
        public int pickRandomIndex(Trainer trainer)
        {
            Random random = new();

            if (trainer.getBeltCount() == 1)
                return 0;

            if (trainer.getBeltCount() == 0)
                return 0;

            int rnd = random.Next(trainer.getBeltCount());

            if (rnd == trainer.getBeltCount())
            {
                return rnd - 1;
            }

            return rnd;
        }

        public void printOutcome(string name, Trainer trainer, int pokeBallIndex)
        {
            Console.WriteLine("");
            Console.WriteLine($"{name} Won !");
            Console.WriteLine("");
            Console.WriteLine(trainer.returnPokeball(pokeBallIndex));
            Console.WriteLine("");
            
        }

        public void printDraw(int rnd1, int rnd2)
        {
            Console.WriteLine("");
            Console.WriteLine(trainer1.returnPokeball(rnd1));
            Console.WriteLine(trainer2.returnPokeball(rnd2));
            Console.WriteLine("");
        }

        public int returnTottalRounds()
        {
            return this.tottalRounds;
        }
       
        
    }
}
