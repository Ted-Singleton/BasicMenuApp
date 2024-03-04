internal class Program
{

    //We need to keep asking for the username and password until an input is received
    private static string HandleInput(string prompt)
    {
        string? input = "";
        bool canContinue = false;
        while (!canContinue)
        {
            //Ask for and take input
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                //If the input is empty, tell the user and loop again
                Console.WriteLine("Input cannot be empty");
            }
            else
            {
                canContinue = true;
            }
        }
        return input;
    }

    private static void Main(string[] args)
    {
        //Initialise our login and menu variables
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

        //We also need a bool to keep the program running
        bool running = true;

        //Initialise our input variables
        string? username = "", password = "";

        //get the username and password
        username = HandleInput("Please enter your username: ");
        password = HandleInput("Please enter your password: ");


        //Now we can check the username and password
        //If they're correct, we can display the menu
        if (username.ToLower() == correctUsername.ToLower() && password == correctPassword)
        {
            //We now initialise our selection variable
            string? selection = "";
            //and start our main loop
            while (running)
            {
                //Display the menu
                Console.WriteLine(menu);

                //Take input, just like before
                selection = HandleInput("Please Select an option: ");

                
                //Now we can check the selection, and act accordingly
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
        //if either the username or password is incorrect, tell the user and close the application
        else
        {
            Console.WriteLine("Incorrect username or password.");
        }
    }
}