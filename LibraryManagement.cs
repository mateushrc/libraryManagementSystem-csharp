namespace LibraryManagementSystem;

class LibraryManagement
{
    private static readonly List<Book> books = new();
    public static IReadOnlyList<Book> All => books;
    public static void Add(Book book)
    {
        books.Add(book);
    }
    public static void Show()
    {
        Console.Clear();
        Console.WriteLine("Library");
        Console.WriteLine("-------------------");
        Console.WriteLine("1 - Add Book");
        Console.WriteLine("2 - Remove Book");
        Console.WriteLine("3 - List Books");
        Console.WriteLine("0 - Back");
        Console.WriteLine("-------------------");
        Console.Write("Choose: ");

        string? inputString = Console.ReadLine();
        if (!int.TryParse(inputString, out int input)) { Error("Invalid Input"); }

        switch (input)
        {
            case 1: AddBook(); break;
            case 2: RemoveBook(); break;
            case 3: ListBooks(); break;
            case 0: Menu.Show(); break;
            default: Error("Invalid Input"); break;
        }
        Console.ReadKey();
    }
    private static void AddBook()
    {
        Console.Clear();
        Console.WriteLine("Add Book");
        Console.WriteLine("-------------------");
        Console.Write("Enter book name: ");
        string? name = Console.ReadLine();
        Console.Write("Enter author name: ");
        string? author = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(author))
            Error("All fields are required!");

        Book newBook = new(name!, author!);
        Add(newBook);
        Console.WriteLine("\nBook added successfully!");
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
        Show();
    }
    private static void ListBooks()
    {
        Console.Clear();
        Console.WriteLine("List of Books");
        Console.WriteLine("-------------------");

        if (All.Count == 0)
        {
            Console.WriteLine("No books found.");
        }
        else
        {
            foreach (var book in All)
            {
                Console.WriteLine($"- {book.Name} (by {book.Author})");
            }
        }

        Console.WriteLine("-------------------");
        Console.WriteLine("Press any key to return");
        Console.ReadKey();
        Show();
    }
    private static void RemoveBook()
    {
        Console.Clear();
        Console.WriteLine("Remove Book");
        Console.WriteLine("-------------------");

        if (All.Count == 0)
        {
            Console.WriteLine("No books to remove.");
            Console.ReadKey();
            Show();
            return;
        }

        for (int b = 0; b < All.Count; b++)
        {
            Console.WriteLine($"{b + 1} - {All[b].Name} (by {All[b].Author})");
        }

        Console.Write("\nEnter the number of the book to remove: ");
        string? inputString = Console.ReadLine();
        if (!int.TryParse(inputString, out int index) || index < 1 || index > All.Count)
        {
            Error("Invalid selection.");
        }

        books.RemoveAt(index - 1);
        Console.WriteLine("\nBook removed successfully!");
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
