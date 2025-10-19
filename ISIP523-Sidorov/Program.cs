using System.Diagnostics;

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
            BookAdd();
            BooksOutput();
            Console.WriteLine("Книга успешно добавлена!");
            break;
        case "2":
            BookDelete();
            BooksOutput();
            Console.WriteLine("Книга успешно удалена!");
            break;
        case "3":
            BookSearch();
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
  
}

int SafeIntInput()
{
    if (int.TryParse(Console.ReadLine(), out int output)) 
    {
        return output;
    }
    else 
    {
        Console.WriteLine("Некорректный ввод!");
        Console.Write("Повторный ввод: ");
        return SafeIntInput();
    }
}


void BookAdd()
{
    Console.Write("Введите название книги: ");
    string name = Console.ReadLine();

    Console.Write("Введите автора: ");
    string author = Console.ReadLine();

    Console.WriteLine("Выберите ID жанра:\n" +
        "1 - Детектив\n" +
        "2 - Научная фантастика\n" +
        "3 - Роман\n" +
        "4 - Фантастика\n" +
        "5 - Приключение\n" +
        "6 - Триллер\n" +
        "7 - Историческая литература");
    Console.Write("ID: ");
    int genreID = SafeIntInput();
    while (genreID <= 0 || genreID > 7) 
    {
        Console.WriteLine("Введён неправильный идентификатор!");
        Console.Write("ID: ");
        genreID = SafeIntInput();
    }
    Genre genre = (Genre)genreID;

    Console.Write("Введите цену: ");
    int price = SafeIntInput();
    while (price <= 0)
    {
        Console.WriteLine("Установлена неправильная цена!");
        Console.Write("Введите цену: ");
        price = SafeIntInput();
    }


    Book newBook = new Book(Book.Count, name, author, genre, price);
    BooksList.Add(newBook);

}


void BookDelete()
{
    Console.Write("Введите ID книги: ");
    int rem = SafeIntInput() - 1;
    while (rem < 0 || rem > BooksList.Count - 1)
    {
        Console.WriteLine("Введён неправильный идентификатор!");
        rem = SafeIntInput();
    }
    BooksList.RemoveAt(rem);
}


void BookSearch()
{
    Console.WriteLine("Введите категорию поиска:\n" +
        "1. ID.\n" +
        "2. Название.\n" +
        "3. Жанр.\n" +
        "4. Автор\n" +
        "5. Цена");
    int search_cat = SafeIntInput();
    while (search_cat <= 0 ||  search_cat > 5) 
    {
        Console.WriteLine("Введена неправильная категория поиска!");
        Console.Write("Введите категорию поиска: ");
        search_cat = SafeIntInput();
    }

    switch (search_cat)
    {

        case 1:
            Console.Write("ID: ");
            int search_id =SafeIntInput();
            while (search_id <= 0 || search_id > BooksList.Count)
            {
                Console.WriteLine("Неправильный индекс!");
                Console.Write("ID: ");
                search_id = SafeIntInput();
            }
            foreach (Book book in BooksList)
            {
                if (search_id == book.BookId)
                {
                    Output(book);
                    Console.WriteLine();
                }
            }
            break;


        case 2:
            Console.Write("Поиск: ");
            string search_name = Console.ReadLine().ToLower();
            foreach (Book book in BooksList)
            {
                if (book.BookName.ToLower().Contains(search_name))
                {
                    Output(book);
                    Console.WriteLine();
                }
            }
            break;


        case 3:
            Console.WriteLine("Выберите ID жанра:\n" +
        "1 - Детектив\n" +
        "2 - Научная фантастика\n" +
        "3 - Роман\n" +
        "4 - Фантастика\n" +
        "5 - Приключение\n" +
        "6 - Триллер\n" +
        "7 - Историческая литература");
    Console.Write("ID: ");
    int genreID = SafeIntInput();
    while (genreID <= 0 || genreID > 7) 
    {
        Console.WriteLine("Введён неправильный идентификатор!");
        Console.Write("ID: ");
        genreID = SafeIntInput();
    }
    Genre search_genre = (Genre)genreID;
            foreach (Book book in BooksList)
            {
                if (search_genre == book.BookGenre)
                {
                    Output(book);
                    Console.WriteLine();
                }
            }
            break;


        case 4:
            Console.Write("Поиск: ");
            string search_author = Console.ReadLine().ToLower();
            foreach (Book book in BooksList)
            {
                if (book.BookAuthor.ToLower().Contains(search_author))
                {
                    Output(book);
                    Console.WriteLine();
                }
            }
            break;


        case 5:
            Console.Write("Минимальная цена: ");
            int search_min_price = SafeIntInput();
            while (search_min_price <= 0)
            {
                Console.WriteLine("Установлена неправильная цена!");
                Console.Write("Минимальная цена: ");
                search_min_price = SafeIntInput();
            }

            Console.Write("Максимальная цена: ");
            int search_max_price = SafeIntInput();
            while (search_max_price <= 0)
            {
                Console.WriteLine("Установлена неправильная цена!");
                Console.Write("Максимальная цена: ");
                search_max_price = SafeIntInput();
            }

            foreach (Book book in BooksList)
            {
                if (search_min_price <= book.BookPrice && search_max_price >= book.BookPrice)
                {
                    Output(book);
                    Console.WriteLine();
                }
            }
            break;
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

void BooksOutput()
{
    foreach (Book book in BooksList)
    {
        Output(book);
        Console.WriteLine();
    }
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