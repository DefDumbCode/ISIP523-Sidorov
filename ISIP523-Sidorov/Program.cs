using System.Diagnostics;

List<Book> BooksList = new List<Book> 
{
    new Book(1, "Этюд в багроых тонах", "Артур Конан Дойл", Genre.Detective, 1887, 899),
    new Book(2, "Затерянный мир", "Артур Конан Дойл", Genre.SciFi, 1912, 799),
    new Book(3, "Гарри Поттер и философский камень",  "Джоан Кэтлин Роулинг", Genre.Fantasy, 1997, 699),
    new Book(4, "Гарри Поттер и Тайная комната", "Джоан Кэтлин Роулинг", Genre.Fantasy, 1998, 799),
    new Book(5, "Гарри Поттер и Узник Азкабана", "Джоан Кэтлин Роулинг", Genre.Fantasy, 1999, 749),
    new Book(6, "Евгений Онегин", "Александр Сергеевич Пушкин", Genre.Roman, 1833, 899)
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
            BooksOutput(BooksList);
            Console.WriteLine("Книга успешно добавлена!");
            break;
        case "2":
            BookDelete();
            BooksOutput(BooksList);
            Console.WriteLine("Книга успешно удалена!");
            break;
        case "3":
            BookSearch();
            break;
        case "4":
            BookSort();
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


    Console.Write("Введите год издания:");
    int year = SafeIntInput();

    Book newBook = new Book(Book.Count, name, author, genre, year, price);
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
        "5. Цена\n" +
        "6. Год издания");
    int search_cat = SafeIntInput();
    while (search_cat <= 0 ||  search_cat > 6) 
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
      
            var search_by_id = BooksList.Where(b => b.BookId == search_id).ToList();
            foreach (var book in search_by_id)
            {
                Output(book);
            }
            break;


        case 2:
            Console.Write("Поиск: ");
            string search_name = Console.ReadLine().ToLower();
            var search_by_name = BooksList.Where(b => b.BookName.ToLower().Contains(search_name)).ToList();
            foreach (var book in search_by_name)
            {
                Output(book);
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
            var search_by_genre = BooksList.Where(b => b.BookGenre == search_genre).ToList();
            foreach (var book in search_by_genre)
            {
                Output(book);
            }
            break;


        case 4:
            Console.Write("Поиск: ");
            string search_author = Console.ReadLine().ToLower();
            var search_by_author = BooksList.Where(b => b.BookAuthor.ToLower().Contains(search_author)).ToList();
            foreach (var book in search_by_author)
            {
                Output(book);
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
            while (search_max_price <= 0 || search_min_price > search_max_price)
            {
                Console.WriteLine("Установлена неправильная цена!");
                Console.Write("Максимальная цена: ");
                search_max_price = SafeIntInput();
            }

            var search_by_price = BooksList.Where(b => b.BookPrice <= search_max_price && b.BookPrice >= search_min_price).ToList();
            foreach (var book in search_by_price)
            {
                Output(book);
            }
            break;
        case 6:
            Console.Write("Минимальный год: ");
            int search_min_year = SafeIntInput();

            Console.Write("Максимальный год: ");
            int search_max_year = SafeIntInput();
            while (search_min_year > search_max_year)
            {
                Console.WriteLine("Установлен неправильный год!");
                Console.Write("Максимальный год: ");
                search_max_price = SafeIntInput();
            }

            var search_by_year = BooksList.Where(b => b.BookYear <= search_max_year && b.BookYear >= search_min_year).ToList();
            foreach (var book in search_by_year)
            {
                Output(book);
            }
            break;
    }
}

void BookSort()
{
    Console.WriteLine("Выберите категорию сортировки:\n" +
        "1. Название\n" +
        "2. Год издания\n" +
        "3. ID");
    int sort_cat = SafeIntInput();
    while (sort_cat <= 0 || sort_cat > 3) 
    {
        Console.WriteLine("Введена неправильная категория сортировки!");
        Console.Write("Введите категорию сортировки: ");
        sort_cat = SafeIntInput();
    }

    switch (sort_cat)
    {
        case 1: 
            var sorted_list_name = BooksList.OrderBy(b =>  b.BookName).ToList();
            BooksOutput(sorted_list_name);
            BooksList = sorted_list_name;
            break; 
        case 2:
            var sorted_list_year = BooksList.OrderBy(b => b.BookYear).ToList();
            BooksOutput(sorted_list_year);
            BooksList = sorted_list_year;
            break;
        case 3:
            var sorted_list_id = BooksList.OrderBy(b => b.BookYear).ToList();
            BooksOutput(sorted_list_id);
            BooksList = sorted_list_id;
            break;
    }
}

void Output(Book book)
{
    Console.WriteLine($"ID книги: {book.BookId}\n" +
        $"Название книги: {book.BookName}\n" +
        $"Автор: {book.BookAuthor}\n" +
        $"Жанр: {book.BookGenre}\n" +
        $"Год издания: {book.BookYear}\n" +
        $"Цена: {book.BookPrice}");
}

void BooksOutput(List<Book> list)
{
    foreach (Book book in list)
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
    public int BookYear;
    public int BookPrice;


    public Book(int bookId, string bookName, string bookAuthor, Genre bookGenre, int bookYear, int bookPrice)
    {
        BookId = bookId;
        BookName = bookName;
        BookAuthor = bookAuthor;
        BookGenre = bookGenre;
        BookYear = bookYear;
        BookPrice = bookPrice;
    }
}