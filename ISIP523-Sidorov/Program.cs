
List<Product> ProductsList = new List<Product>();
string input = " ";
while (input != "3")
{
    Console.WriteLine("1. Добавить новый элемент:");
    Console.WriteLine("2. Удалить элемент:");
    Console.WriteLine("3. Заказать поставку товара:");
    Console.WriteLine("4. Продать товар:");
    Console.WriteLine("5. Поск:");
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
            break;
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
    int rem = int.Parse(Console.ReadLine());
    ProductsList.RemoveAt(rem);
}


void ProductPurchase()
{
    Console.Write("Введите индекс товара:");
    int purch = int.Parse(Console.ReadLine());

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
    int purch = int.Parse(Console.ReadLine());

    Console.Write("Введите кол-во продаваемого товара:");
    int amount = int.Parse(Console.ReadLine());
    while (amount > ProductsList[purch].ProductQuantity && amount < 0)
    {
        Console.WriteLine("Неправильное количество продаваемых товаров!");
        amount = int.Parse(Console.ReadLine());
    }

    ProductsList[purch].ProductQuantity -= amount;
}


public enum ProductCategory
{
    Vegetables,
    Fruits,
    Dairy_Products,
    Meat_n_Phish,
    Snacks,
    Sweets,
    Bread
}

public class Product
{
    public static int Count = 0;

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