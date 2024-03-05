





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

        Console.WriteLine("Give your a charmander a name : ");
        string name = Console.ReadLine();

        Charmander pokemone = new Charmander(name);
        Console.WriteLine("");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(pokemone.battleCry());
        }

        Console.WriteLine("");
        Console.WriteLine("************************************************");
        
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


