internal class Program
{
    //We need to keep asking for the username and password until an input is received
    //We will use this a few times, so we break it out into a function
    private static string HandleInput(string prompt)
    {
        string? input = "";
        bool tryAgain = true;
        /*EDIT: I changed this to a do-while loop, since we want to check user input at least once. My previous version forced this functionality in a while loop, making the code less readable and wasting some time.
        I also simplified the if statement, since we can use the same variable for both outputting an error and keeping us in the loop, saving a little memory. */
        do
        {
            //Ask for and take input
            Console.Write(prompt);
            input = Console.ReadLine();
            tryAgain = string.IsNullOrEmpty(input);
            if (tryAgain)
            {
                //If the input is empty, tell the user and loop again
                Console.WriteLine("Input cannot be empty, please try again.");
            }
        }while(tryAgain);
        return input;
    }

    //We need to check the username and password, so we can break this out into a function.
    //We pass in the dictionary of correct login details, rather than create it here, since we may want to use it in other functions later
    private static bool CheckPassword(string un, string pw, Dictionary<string, string> details)
    {
        //check if the input username is in the dictionary in a case-insensitive way
        if(details.ContainsKey(un.ToLower()))
        {
            //if it is, check if the password matches and return that value
            return details[un.ToLower()] == pw;
        }
        else
        {
            //if the username isn't in the dictionary, return false
            return false;
        }
    }

    private static void Main(string[] args)
    {
        //Initialise our correct login details
        //EDIT: Made this a dictionary so we can handle multiple users
        Dictionary<string, string> correctLoginDetails = new Dictionary<string, string>
        {
            //I changed the stored usernames to lower case, so we can still perform a case-insensitive check
            {"ted", "Password42!"},
            {"trevor", "Password123!"},
            {"alice", "Password!"},
            {"bob", "Bassword!"}
        };

        //Initialise our input variables
        string username, password;

        //get the username and password
        username = HandleInput("Please enter your username: ");
        password = HandleInput("Please enter your password: ");

        //EDIT: created a boolean to store the result of the login check
        //This isn't optimal, but I find it makes the code more readable than having the CheckPassword function call directly in the if statement
        bool loginSuccess = CheckPassword(username, password, correctLoginDetails);

        //Now we can check the username and password
        //If they're correct, we can display the menu
        if (loginSuccess)
        {
            //EDIT: moved these inside the if statement, since we only need them if the user successfully logs in
            //We can use a string to store our menu
            string menu = $"""
            Welcome, {username}!
            --Main Menu--
                1. Create new member
                2. Edit member
                3. View member
                4. Delete member
                X. Exit
            """;

            //We also need a bool to keep the program running
            bool running = true;

            //We now initialise our selection variable
            string selection;
            //and start our main loop
            //EDIT: I changed this to a do-while loop, since we want the menu to be displayed at least once. We save some time by not having to check the condition before the loop starts
            do
            {
                //Display the menu
                Console.WriteLine(menu);

                //Take input, just like before
                selection = HandleInput("Please Select an option: ").ToLower();

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
                        //If the user selects X, we can set running to false, and the program will exit
                        running = false;
                        break;
                    default:
                        //This will show if the user enters something, but not a valid option
                        Console.WriteLine("Invalid selection, please try again");
                        break;
                }
            } while (running);
        }
        //If either the username or password is incorrect, tell the user and close the application
        else
        {
            Console.WriteLine("Incorrect username or password.");
        }
    }
}