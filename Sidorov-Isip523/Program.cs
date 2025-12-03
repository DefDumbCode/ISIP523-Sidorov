using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidorov_Isip523
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Products> products = Core.Context.Products.ToList();
            List<Clients> clients = Core.Context.Clients.ToList();
            List<Cart> carts = new List<Cart>();
            List<Order> orders = new List<Order>();
            List<PVZ> PVZs = Core.Context.PVZ.ToList();
            Clients client = null;

            string choice = " ";
            while (choice != "5")
            {
                Console.Clear();
                Menu();
                Console.Write("Выбор: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        if (clients.Count() > 0)
                        {
                            client = Login();
                        }
                        else
                        {
                            Console.WriteLine("Учетных записей нет в базе");
                        }
                        break;
                    case "2":
                        client = NewLogin();
                        break;
                    case "3":
                        Catalog(client);
                        break;
                    case "4":
                        CartShow(client);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор!");
                        break;
                }

            }


            Clients Login()
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();
                var user = clients.FirstOrDefault(c => c.Login == login && c.Password == password);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    Console.WriteLine("Неправильный логин или пароль");
                    return Login();
                }
            }

            Clients NewLogin()
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password1 = Console.ReadLine();
                Console.Write("Повторите пароль: ");
                string password2 = Console.ReadLine();
                if (password1 == password2)
                {
                    Clients user = new Clients { Login = login, Password = password1 };
                    Core.Context.Clients.Add(user);
                    clients.Add(user);
                    Core.Context.SaveChanges();
                    return user;
                }
                else
                {
                    Console.WriteLine("Пароли не совпадают");
                    return NewLogin();
                }
            }

            void Catalog(Clients user)
            {
                Console.WriteLine("===Каталог товаров===");
                foreach (var item in products)
                {
                    item.ProductShow();
                }

                if (user == null)
                {
                    Console.Write("Вы не вошли в аккаунт. Добавление товаров в корзину недоступно.\n" +
                        "Нажмите Enter для возвращения в меню ");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("Покупаете или просто посмотреть?\n" +
                        "1) М..мнем..мнем..Покупаю!\n" +
                        "2) Нет, я просто смотрю.\n" +
                        "Выбор: ");
                    int look = IntInput();
                    while (look != 1 && look != 2)
                    {
                        Console.Write("Непрвильный выбор!\n" +
                            "Попробуйте ещё раз: ");
                        look = IntInput();
                    }

                    if (look == 1)
                    {
                        int keep_buy = 1;
                        while (keep_buy != 2)
                        {
                            Console.Write("Введите точное название товара, который хотите заказать: ");
                            string ProdName = Console.ReadLine();
                            var prod = products.FirstOrDefault(p => p.Name == ProdName);
                            while (prod == null)
                            {
                                Console.Write("Товар не найден, попробуйте снова: ");
                                ProdName = Console.ReadLine();
                                prod = products.FirstOrDefault(p => p.Name == ProdName);
                            }
                            Console.Write("Введите количество: ");
                            int amount = IntInput();
                            while (amount < 0)
                            {
                                Console.Write("Указано неправильное количество!\n" +
                                    "Попробуйте еще раз: ");
                                amount = IntInput();
                            }

                            Cart cart = new Cart { UserID = client.ID, Amount = amount, ProductID = prod.ID };
                            Core.Context.Cart.Add(cart);
                            carts.Add(cart);
                            Core.Context.SaveChanges();
                            Console.Write("Товар добавлен в корзину.\n" +
                                "1) Продолжить покупки.\n" +
                                "2) Завершить.\n" +
                                "Выбор: ");
                            keep_buy = IntInput();
                            while (keep_buy != 1 && keep_buy != 2)
                            {
                                Console.Write("Неправильный выбор!\n" +
                                    "Попробуйте снова: ");
                                keep_buy = IntInput();
                            }
                        }
                    }
                }
            }

            void CartShow(Clients user)
            {
                Console.WriteLine("===Корзина===");
                carts = Core.Context.Cart.ToList().Where(c => c.UserID == user.ID).ToList();
                foreach (var cart in carts)
                {
                    Console.WriteLine($"{products.FirstOrDefault(p => p.ID == cart.ProductID).Name}.\n" +
                        $"Количество: {cart.Amount}\n");
                }

                Console.Write("Действия:\n" +
                    "1) Купить все.\n" +
                    "2) Купить один товар.\n" +
                    "3) Вернуться в меню.\n" +
                    "Выбор: ");
                int cart_choice = IntInput();
                switch (cart_choice)
                {
                    case 1:
                        Console.WriteLine("Выберите ПВЗ:");
                        foreach(var pvz in PVZs)
                        {

                        }
                        foreach (var cart in carts)
                        {
                            //Order order = new Order { ClientID=client.ID, CartID = cart.ID, };
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }

            int IntInput()
            {
                if (int.TryParse(Console.ReadLine(), out int output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                    Console.Write("Повторный ввод: ");
                    return IntInput();
                }
            }


            void Menu()
            {
                Console.WriteLine("===WILDBEBRIES===\n" +
                    "1) Войти в аккаунт.\n" +
                    "2) Зарегистрироваться\n" +
                    "3) Каталог товаров.\n" +
                    "4) Корзина.\n" +
                    "5) Выйти.");
            }
        }
    }
}
