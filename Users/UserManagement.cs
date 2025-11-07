namespace LibraryManagementSystem;

class UserManagement
{
    private static readonly List<User> users = new();
    public static IReadOnlyList<User> All => users;
    public static User? LoggedUser { get; private set; }

    public static void Add(User user)
    {
        users.Add(user);
    }

    public static void SetLoggedUser(User user)
    {
        LoggedUser = user;
    }
    public static void Show()
    {
        Console.Clear();
        Console.WriteLine("User Management");
        Console.WriteLine("---------------");
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Register");
        Console.WriteLine("0 - Back");
        Console.WriteLine("---------------");
        Console.Write("Choose: ");

        string? inputString = Console.ReadLine();
        if (!int.TryParse(inputString, out int input)) Error("Invalid Input");

        switch (input)
        {
            case 1: Login(); break;
            case 2: Register(); break;
            case 0: Menu.Show(); break;
            default: Error("Invalid Input"); break;
        }
        Console.ReadKey();
    }

    public static bool Auth()
    {
        return LoggedUser != null;
    }

    public static void Register()
    {
        Console.Clear();
        Console.WriteLine("Register");
        Console.WriteLine("---------------");
        Console.Write("Enter your username: ");
        string? username = Console.ReadLine();
        Console.Write("\nEnter your password: ");
        string? password = Console.ReadLine();
        Console.Write("\nEnter your email: ");
        string? email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            Error("Error: All fields are required!");

        foreach (var user in All)
        {
            if (username == user.Username)
                Error("Error: This username already exists!");
            if (email == user.Email)
                Error("Error: This email already in use!");
        }

        User newUser = new User(username!, password!, email!);
        Add(newUser);
        Console.WriteLine("User registed in successfully!");
        Console.ReadKey();
        Show();
    }

    private static void Login()
    {
        Console.Clear();
        Console.WriteLine("Login");
        Console.WriteLine("----------------");
        Console.Write("Username: ");
        string? username = Console.ReadLine();
        Console.Write("\nPassword: ");
        string? password = Console.ReadLine();
        Console.Write("\nEmail: ");
        string? email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            Error("Error: All fields are required!");

        User? userFound = All.FirstOrDefault(u =>
            u.Username == username && u.Password == password && u.Email == email);

        if (userFound != null)
        {
            SetLoggedUser(userFound);
            Console.WriteLine("User logged in successfully!");
        }
        else
        {
            Error("You made a mistake / this user does not exist.");
        }

        Console.WriteLine("Press any key to return");
        Console.ReadKey();
        Show();
    }

    public static void Error(string output)
    {
        Console.WriteLine("\n");
        Console.WriteLine(output);
        Console.WriteLine("Press any key to return");
        Console.ReadKey();
        Show();
        return;
    }
}
