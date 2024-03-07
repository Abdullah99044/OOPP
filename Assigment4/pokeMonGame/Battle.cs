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

        public Trainer trainer1;
        public Trainer trainer2;
        public int tottalRounds;
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
                Console.WriteLine(rnd1);
                Console.WriteLine(rnd2);
                Console.WriteLine("");
                Console.WriteLine($"Round {rounds}");
                Console.WriteLine("");

                //Pick random pokeballs
                PokeBall pokeBall1 = trainer1.belt[rnd1];
                PokeBall pokeBall2 = trainer2.belt[rnd2];

                Console.WriteLine(trainer1.throwPokeball(rnd1));
                Console.WriteLine(trainer2.throwPokeball(rnd2));

                var pokemone1 = pokeBall1.pokemon;
                var pokemone2 = pokeBall2.pokemon;

                //Calaculate the outcome
                if (pokemone1.strength == pokemone2.weakness)
                {
                    printOutcome(pokeBall1.pokemon.name, trainer2, rnd2);
                    previousWinnerPokemon = rnd1;
                    previousWinnerTrainer = trainer1;

                    //The winner stays in the battle while the loser removed
                    trainer2.belt.RemoveAt(rnd2);
                    rnd2 = pickRandomIndex(trainer2);
                }
                else if (pokemone2.strength == pokemone1.weakness)
                {
                    printOutcome(pokeBall2.pokemon.name, trainer1, rnd1);
                    previousWinnerPokemon = rnd2;
                    previousWinnerTrainer = trainer2;

                    //The winner stays in the battle while the loser removed
                    trainer1.belt.RemoveAt(rnd1);
                    rnd1 = pickRandomIndex(trainer1);
                }
                else if (pokemone2.strength == pokemone1.strength)
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

                        previousWinnerTrainer.belt.RemoveAt(previousWinnerPokemon);

                        //The previous winner will pick new pokeball

                        if (previousWinnerTrainer.name == trainer1.name)
                            rnd1 = pickRandomIndex(trainer1);
                        else if (previousWinnerTrainer.name == trainer2.name)
                            rnd2 = pickRandomIndex(trainer2);

                        previousWinnerTrainer = null;
                        previousWinnerPokemon = default;
                    }
                }

                Console.WriteLine("");
                Console.WriteLine($"{trainer1.name} has {trainer1.belt.Count} pokeballs left in his belt");
                Console.WriteLine($"{trainer2.name} has {trainer2.belt.Count} pokeballs left in his belt");

                //Battle outcome :
                if (trainer1.belt.Count == 0 || trainer2.belt.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Battle result is draw!");
                    break;
                }
                else if (trainer2.belt.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"{trainer1.name} won the battle!");
                }
                else if (trainer1.belt.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"{trainer2.name} won the battle!");
                }

                // Avoiding ifinite loop when the last unused Pokemon of trainer1 has the same strength as the last unused Pokemon of trainer2
                // Which cause an infinite loop because there will be no winner
                if (trainer1.belt.Count == 1 && trainer2.belt.Count == 1)
                {
                    if (pokeBall1.pokemon.strength == pokeBall2.pokemon.strength)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Battle result is draw!");
                        break;
                    }
                }

                rounds++;

            }
            while (trainer1.belt.Count > 0 && trainer2.belt.Count > 0);

            this.tottalRounds = rounds;
        }
        

        //Generate a random number that can be used as index
        public int pickRandomIndex(Trainer trainer)
        {
            Random random = new();

            if (trainer.belt.Count == 1)
                return 0;

            if (trainer.belt.Count == 0)
                return 0;

            int rnd = random.Next(trainer.belt.Count);

            if (rnd == trainer.belt.Count)
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
