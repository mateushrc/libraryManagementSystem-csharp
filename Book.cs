namespace LibraryManagementSystem;

class Book
{
    public string Name { get; private set; }
    public string Author { get; private set; }

    public Book(string name, string author)
    {
        Name = name;
        Author = author;
    }
}