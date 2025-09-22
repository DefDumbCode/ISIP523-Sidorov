
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
    }
}



void ProductAdd()
{
    Console.Write("Введите название товара: ");
    string name = Console.ReadLine();

    Console.Write("Введите цену товара: ");
    double price = double.Parse(Console.ReadLine());

    Console.Write("Введите кол-во товара: ");
    int quantity = int.Parse(Console.ReadLine());

    bool have = true;
    if (quantity < 0)
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