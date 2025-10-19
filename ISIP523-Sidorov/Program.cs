List<Book> BooksList = new List<Book> 
{
    new Book(1, "Этюд в багроых тонах", "Артур Конан Дойл", Genre.Detective, 899),
    new Book(2, "Затерянный мир", "Артур Конан Дойл", Genre.SciFi, 799),
    new Book(3, "Гарри Поттер и философский камень",  "Джоан Кэтлин Роулинг", Genre.Fantasy, 699),
    new Book(4, "Гарри Поттер и Тайная комната", "Джоан Кэтлин Роулинг", Genre.Fantasy, 799),
    new Book(5, "Гарри Поттер и Узник Азкабана", "Джоан Кэтлин Роулинг", Genre.Fantasy, 749),
    new Book(6, "Евгений Онегин", "Александр Сергеевич Пушкин", Genre.Roman, 899)
};
string input = " ";
while (input != "7")
{
    Console.WriteLine("\n/_____________________/");
    Console.WriteLine("1. Добавить новую книгу.");
    Console.WriteLine("2. Удалить книгу.");
    Console.WriteLine("3. Поиск.");
    Console.WriteLine("4. Сортировка.");
    Console.WriteLine("5. Самая дорогая и самая дешёвая книги.");
    Console.WriteLine("6. Группировка по авторам.");
    Console.WriteLine("7. Выход.");
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
            //BookAdd();
            break;
        case "2":
            //BookDelete();
            break;
        case "3":
            //BookSearch();
            break;
        case "4":
            //BookSort();
            break;
        case "5":
            //BookMaxMin();
            break;
        case "6":
            //BookGroup();
            break;
        case "7":
            break;
        default:
            Console.WriteLine("Неправильная команда!");
            break;
    }
    foreach (Book product in BooksList)
    {
        Output(product);
        Console.WriteLine();
    }
}

void Output(Book book)
{
    Console.WriteLine($"ID книги: {book.BookId}\n" +
        $"Название книги: {book.BookName}\n" +
        $"Автор: {book.BookAuthor}\n" +
        $"Жанр: {book.BookGenre}\n" +
        $"Цена: {book.BookPrice}");
}

public enum Genre
{
    Detective = 1,
    SciFi,
    Roman,
    Fantasy,
    Journey,
    Thriller,
    Historic
}

public class Book
{
    public static int Count = 6;
    public int BookId;
    public string BookName;
    public string BookAuthor;
    public Genre BookGenre;
    public int BookPrice;


    public Book(int bookId, string bookName, string bookAuthor, Genre bookGenre, int bookPrice)
    {
        BookId = bookId;
        BookName = bookName;
        BookAuthor = bookAuthor;
        BookGenre = bookGenre;
        BookPrice = bookPrice;
    }
}