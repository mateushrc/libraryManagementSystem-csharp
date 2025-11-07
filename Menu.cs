namespace LibraryManagementSystem;

public class Menu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("-------------------");
            Console.WriteLine("1 - Book Management");
            Console.WriteLine("2 - User Management");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("-------------------");
            Console.Write("Choose: ");
            string? inputString = Console.ReadLine();
            if (!int.TryParse(inputString, out int input)) { Error("Invalid Input"); }

            switch (input)
            {
                case 1:
                    if (UserManagement.Auth()) LibraryManagement.Show();
                    else Console.WriteLine("log in fist");
                    break;
                case 2: UserManagement.Show(); break;
                case 0: Environment.Exit(0); break;
                default: Error("Invalid Input"); break;
            }
            Console.ReadKey();
        }
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
