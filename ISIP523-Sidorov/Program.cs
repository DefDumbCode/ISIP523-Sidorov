
using System.Runtime;

List<Product> ProductsList = new List<Product>();
string input = " ";
while (input != "6")
{
    Console.WriteLine("\n/_____________________/");
    Console.WriteLine("1. Добавить новый элемент.");
    Console.WriteLine("2. Удалить элемент.");
    Console.WriteLine("3. Заказать поставку товара.");
    Console.WriteLine("4. Продать товар.");
    Console.WriteLine("5. Поск.");
    Console.WriteLine("6. Выход.");
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
            ProductAdd();
            break;
        case "2":
            ProductDelete();
            break; 
        case "3":
            ProductPurchase();
            break;
         case "4":
            ProductSell();
            break;
        case "5":
            ProductSearch();
            break;
        case "6":
            break;
        default: Console.WriteLine("Неправильная команда!");
            break;
    }
    foreach (Product product in ProductsList)
    {
        Output(product);
        Console.WriteLine();
    }
}



void ProductAdd()
{
    Console.Write("Введите название товара: ");
    string name = Console.ReadLine();

    Console.Write("Введите цену товара: ");
    double price = double.Parse(Console.ReadLine());

    while (price <= 0)
    {
        Console.WriteLine("Цена не должна быть отрицательной и равной нулю");
        price = int.Parse(Console.ReadLine());
    }

    Console.Write("Введите кол-во товара: ");
    int quantity = int.Parse(Console.ReadLine());

    while (quantity < 0)
    {
        Console.WriteLine("Невозможно иметь отрицательое кол-во товаров на складе");
        quantity = int.Parse(Console.ReadLine());
    }

    bool have = true;
    if (quantity == 0)
    {
        have = false;
    }
 
    Console.WriteLine("Введите индекс категории:\n" +
        "1 - Овощи\n" +
        "2 - Фрукты\n" +
        "3 - Молочная продукция\n" +
        "4 - Мясо и Рыба\n" +
        "5 - Снэки\n" +
        "6 - Сладости\n" +
        "7 - Выпечка");
    ProductCategory cat = (ProductCategory)int.Parse(Console.ReadLine());

    Product NewProd = new Product(Product.Count, name, price, quantity, have, cat);
    ProductsList.Add(NewProd);

}


void ProductDelete()
{
    Console.Write("Введите индекс товара:");
    int rem = int.Parse(Console.ReadLine()) - 1;
    while (rem < 0 || rem > ProductsList.Count - 1)
    {
        Console.WriteLine("Неправильный индекс!");
        rem = int.Parse(Console.ReadLine());
    }
    ProductsList.RemoveAt(rem);
}


void ProductPurchase()
{
    Console.Write("Введите индекс товара:");
    int purch = int.Parse(Console.ReadLine()) - 1;

    while (purch < 0 || purch > ProductsList.Count - 1)
    {
        Console.WriteLine("Неправильный индекс!");
        purch = int.Parse(Console.ReadLine());
    }

    Console.Write("Введите кол-во заказываемого товара:");
    int amount = int.Parse(Console.ReadLine());
    while (amount < 0) 
    { 
        Console.WriteLine("Нельзя заказать отрицательное кол-во товара! Для продажи используйте другую функцию.");
    }
    ProductsList[purch].ProductQuantity += amount;
}


void ProductSell()
{
    Console.Write("Введите индекс товара:");
    int purch = int.Parse(Console.ReadLine()) - 1;

    while (purch < 0 || purch > ProductsList.Count - 1) 
    {
        Console.WriteLine("Неправильный индекс!");
        purch = int.Parse(Console.ReadLine());
    }

    Console.Write("Введите кол-во продаваемого товара:");
    int amount = int.Parse(Console.ReadLine());
    while (ProductsList[purch].ProductQuantity - amount < 0 || amount < 0)
    {
        Console.WriteLine("Неправильное количество продаваемых товаров!");
        amount = int.Parse(Console.ReadLine());
    }
    Console.Write("Введите адрес доставки: ");
    string address = Console.ReadLine();
    ProductsList[purch].ProductQuantity -= amount;
    if (ProductsList[purch].ProductQuantity == 0) 
    {
        ProductsList[purch].ProductHave = false;
    }
}


void ProductSearch()
{
    Console.WriteLine("Введите категорию поиска:\n" +
        "1. ID.\n" +
        "2. Название.\n" +
        "3. Категория.\n");
    int search_cat = int.Parse(Console.ReadLine()) - 1;

    switch (search_cat)
    {
        case 1:
            Console.Write("ID: ");
            int search_id = int.Parse(Console.ReadLine()) - 1;
            while (search_id < 0 || search_id > ProductsList.Count - 1)
            {
                Console.WriteLine("Неправильный индекс!");
                search_id = int.Parse(Console.ReadLine());
            }
            foreach (Product product in ProductsList) 
            {
                if (search_id - 1 == product.ProductId) 
                {
                    Output(product);
                    Console.WriteLine();
                }
            }
            break;
        case 2:
            Console.Write("Поиск: ");
            string search_name = Console.ReadLine().ToLower();
            foreach (Product product in ProductsList) 
            {
                if (search_name == product.ProductName) 
                {
                    Output(product);
                    Console.WriteLine();
                }
            }
            break;
         case 3:
            Console.WriteLine("Введите индекс категории:\n" +
        "1 - Овощи\n" +
        "2 - Фрукты\n" +
        "3 - Молочная продукция\n" +
        "4 - Мясо и Рыба\n" +
        "5 - Снэки\n" +
        "6 - Сладости\n" +
        "7 - Выпечка");
            ProductCategory search_category = (ProductCategory)int.Parse(Console.ReadLine());
            foreach (Product product in ProductsList) 
            {
                if (search_category == product.Category)
                {
                    Output(product);
                    Console.WriteLine();
                }
            }
            break;
    }
    

}


void Output(Product product)
{
    Console.WriteLine($"ID товара: {product.ProductId}\n" +
        $"Наименование товара: {product.ProductName}\n" +
        $"Цена товара: {product.ProductPrice}\n" +
        $"Количество на складе: {product.ProductQuantity}\n" +
        $"Наличие: {product.ProductHave}\n" +
        $"Категория товара: {product.Category}");
}

public enum ProductCategory
{
    Vegetables = 1,
    Fruits,
    Dairy_Products,
    Meat_n_Phish,
    Snacks,
    Sweets,
    Bread
}

public class Product
{
    public static int Count = 1;

    public int ProductId;
    public string ProductName;
    public double ProductPrice;
    public int ProductQuantity;
    public bool ProductHave;
    public ProductCategory Category;


    public Product(int productId, string productName, double productPrice, int productQuantity, bool productHave, ProductCategory category)
    {
        ProductId = productId;
        ProductName = productName;
        ProductPrice = productPrice;
        ProductQuantity = productQuantity;
        ProductHave = productHave;
        Category = category;
        Count++;
    }
}