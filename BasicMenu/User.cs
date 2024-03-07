namespace BasicMenu
{
    //We want a User class to store the user's details, beyond just username and password
    internal class User
    {
        //We can use properties to store the user's details
        //For now, we'll just store the username, password, name and email with public getters and private setters.
        //Once we get onto developing the menu's functionality, we'll need to be more specific about these access modifiers depending on how we want to implement menu options.
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; set; }
        public string Email { get; private set; }

        //our default constructor requires a username and password. We can set the name and email later
        public User(string username, string password)
        {
            //We force all usernames to be lower case, so we can compare them easily
            Username = username.ToLower();
            Password = password;
            //We can set the name to the username by default
            Name = Username;
            //And the email to "Not set" by default
            Email = "Not set";
        }

        //We can also create a constructor that sets the name and email at the same time
        public User(string username, string password, string name, string email)
        {
            Username = username.ToLower();
            Password = password;
            Name = name;
            Email = email;
        }
    }
}
