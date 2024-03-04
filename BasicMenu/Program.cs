//login to menu (username and password)
//display menu option when selected
//if no input, repeat menu
//usernames not case specific, passwords are

string correctUsername = "Ted";
string correctPassword = "Password42!";
string menu = $"""
    Welcome, {correctUsername}!
    --Main Menu--
        1. Create new member
        2. Edit member
        3. View member
        4. Delete member
        X. Exit
    """;

bool running = true;

Console.WriteLine("Please enter your username: ");
string? username = Console.ReadLine();
Console.WriteLine("Please enter your password: ");
string? password = Console.ReadLine();

if (username.ToLower() == correctUsername.ToLower() && password == correctPassword)
{
    while (running)
    {
        Console.WriteLine(menu);
        Console.WriteLine("Please Select an option: ");
        string? selection = Console.ReadLine().ToLower();

        switch (selection)
        {
            case "1":
                Console.WriteLine("Creating new member...");
                break;
            case "2":
                Console.WriteLine("Editing member...");
                break;
            case "3":
                Console.WriteLine("Viewing member...");
                break;
            case "4":
                Console.WriteLine("Deleting member...");
                break;
            case "x":
                Console.WriteLine("Exiting...");
                running = false;
                break;
            default:
                Console.WriteLine("Invalid selection, please try again");
                break;
        }
    }
}
else
{
    Console.WriteLine("Incorrect username or password.");
}