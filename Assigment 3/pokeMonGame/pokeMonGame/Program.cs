





using pokeMonGame;

Console.WriteLine("Do you want to play ? : (yes/no) ");
string answer = Console.ReadLine();

Console.WriteLine("");
Console.WriteLine("************************************************");
Console.WriteLine("");

if (answer == "Yes" || answer == "yes")
{
    while (true)
    {

        Console.WriteLine("Give Trainer 1 a name : ");
        string trainer1Name = Console.ReadLine();

        Console.WriteLine("Give Trainer 2 a name : ");
        string trainer2Name = Console.ReadLine();

        Trainer trainer1 = new Trainer(trainer1Name);
        Trainer trainer2 = new Trainer(trainer2Name);

        Console.WriteLine("");
        Console.WriteLine("************************************************");
        Console.WriteLine("");

        if (trainer1.belt.Count <= 6)
        {
            for (int i = 0; i != 6; i++)
            {
                Console.WriteLine($"Give Pokemone {i+1} of Trainer {trainer1.name} a name : ");
                string charmanderName = Console.ReadLine();
                Console.WriteLine(trainer1.addPokeballsTotheBelt(charmanderName , i));
               ;
            }
        }

        Console.WriteLine("");
        Console.WriteLine("************************************************");
        Console.WriteLine("");

        if (trainer2.belt.Count <= 6)
        {
            for (int i = 0; i != 6; i++)
            {
                Console.WriteLine($"Give Pokemone {i+1} of Trainer {trainer2.name} a name : ");
                string charmanderName = Console.ReadLine();
                Console.WriteLine(trainer2.addPokeballsTotheBelt(charmanderName, i));
            }
        }

        Console.WriteLine("");
        Console.WriteLine("************************************************");
        Console.WriteLine("");

        int index = 0;
        while(index != 6)
        {
           
            Console.WriteLine(trainer1.throwPokeball(index));
            Console.WriteLine(trainer2.throwPokeball(index));

            Console.WriteLine("");
            Console.WriteLine(trainer1.returnPokeball(index));
            Console.WriteLine(trainer2.returnPokeball(index));
            Console.WriteLine("");

            index++;
        }
        

        Console.WriteLine("");
        Console.WriteLine("************************************************");
        Console.WriteLine("");

        Console.WriteLine("Do you want to quit ? : (yes/no) ");
        answer = Console.ReadLine();
        Console.WriteLine("");

        if (answer == "yes" || answer == "Yes")
            break;
    }
}

Console.WriteLine("");
Console.WriteLine("************************************************");
Console.WriteLine("");
Console.WriteLine("Good bye");


