using BasicMenu;
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
    //We pass in the dictionary of users, rather than create it here, since we may want to use it in other functions later
    private static bool CheckPassword(string un, string pw, Dictionary<string, User> details)
    {
        //check if the input username is in the dictionary in a case-insensitive way
        if(details.ContainsKey(un.ToLower()))
        {
            //if it is, check if the password matches and return that value
            return details[un.ToLower()].Password == pw;
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

        //first we instantiate our users
        User user1 = new User("ted", "Password1","Ted", "tedsingleton6@gmail.com");
        User user2 = new User("trevor", "Password2", "Trevor", "trevor.smith@peregrineresourcing.com");
        User user3 = new User("alice", "Password3");
        User user4 = new User("bob", "Password4");

        //and then we add them to a dictionary
        Dictionary<string, User> users = new Dictionary<string, User>
        {
            {user1.Username, user1},
            {user2.Username, user2},
            {user3.Username, user3},
            {user4.Username, user4}
        };

        //Initialise our input variables
        string username, password;

        //get the username and password
        username = HandleInput("Please enter your username: ");
        password = HandleInput("Please enter your password: ");

        //EDIT: created a boolean to store the result of the login check
        //This isn't optimal, but I find it makes the code more readable than having the CheckPassword function call directly in the if statement
        bool loginSuccess = CheckPassword(username, password, users);

        //Now we can check the username and password
        //If they're correct, we can display the menu
        if (loginSuccess)
        {
            //We can use the appropriate user from the dictionary for their details
            User currentUser = users[username.ToLower()];

            //EDIT: moved these inside the if statement, since we only need them if the user successfully logs in
            //We also need a bool to keep the program running
            bool running = true;

            //We now initialise our selection variable
            string selection;

            //and start our main loop
            //EDIT: I changed this to a do-while loop, since we want the menu to be displayed at least once. We save some time by not having to check the condition before the loop starts
            do
            {
                //We can use a string to store our menu
                //EDIT: Since we're now allowing the user to edit their display name, we have to bring that into the loop so it can update
                string menu = $"""
                Welcome, {currentUser.Name}!
                --Main Menu--
                    1. Create new member
                    2. Edit member
                    3. View member
                    4. Delete member
                    X. Exit
                """;
                //Display the menu
                Console.WriteLine(menu);

                //Take input, just like before
                selection = HandleInput("Please Select an option: ").ToLower();

                //Now we can check the selection, and act accordingly
                switch (selection)
                {
                    case "1":
                        //here, we ask for details to create a new user
                        //the minimum requirement is a username and password
                        Console.WriteLine("Creating new member...");
                        string newUsername = HandleInput("Please enter a username: ");
                        string newPassword = HandleInput("Please enter a password: ");
                        //we could also ask for a name and email, but we'll leave them as default for now
                        users.Add(newUsername, new User(newUsername, newPassword));
                        break;

                    case "2":
                        //we can edit the current user's details
                        //in future, this could be its own breakout menu, allowing the user to select what to edit about their account
                        //for now, we'll just allow them to change their display name
                        Console.WriteLine("Editing member...");
                        currentUser.Name = HandleInput("Please enter a new display name: ");
                        break;

                    case "3":
                        //we can view the current user's details
                        Console.WriteLine("Here are your details:");
                        Console.WriteLine($"Username: {currentUser.Username}");
                        Console.WriteLine($"Display Name: {currentUser.Name}");
                        Console.WriteLine($"Email: {currentUser.Email}");
                        break;

                    case "4":
                        //here, we can delete a user
                        Console.WriteLine("Please select a member to delete:");
                        //we show the usernames of all the users
                        foreach (var user in users)
                        {
                            Console.WriteLine(user.Key);
                        }
                        //and then ask for the username of the user to delete. we also make it lowercase to match the dictionary
                        string deleteUsername = HandleInput("Please enter the username of the member you want to delete: ").ToLower();

                        //if the user exists, we can remove them
                        if(users.ContainsKey(deleteUsername))
                        {
                            users.Remove(deleteUsername);
                            Console.WriteLine("Member deleted.");
                        }
                        //if not, we tell the user that it failed
                        else
                        {
                            Console.WriteLine("Member not found.");
                        }
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