using pokeMonGame;


//Ask the player if he want to play 

Console.WriteLine("Do you want to play ? : (yes/no) ");
string answer = Console.ReadLine();

Console.WriteLine("");
Console.WriteLine("************************************************");
Console.WriteLine("");

if (answer == "Yes" || answer == "yes")
{

    //Create two trainers for the player 

    Console.WriteLine("Give Trainer 1 a name : ");
    string trainer1Name = Console.ReadLine();

    Console.WriteLine("Give Trainer 2 a name : ");
    string trainer2Name = Console.ReadLine();

    Trainer trainer1 = new Trainer(trainer1Name);
    Trainer trainer2 = new Trainer(trainer2Name);

    Arena arena = new Arena(trainer1, trainer2);

    //The player can play in the arena until he quit
    while (true)
    {
        arena.battleArena();

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


