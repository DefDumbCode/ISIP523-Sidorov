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
            Clients client = new Clients();

            string choice = " ";
            while (choice != "5")
            {
                Console.Clear();
                Menu();
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
                        //Catalog();
                        break;
                    case "4":
                        //CartShow();
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
                if(password1 == password2)
                {
                    Clients user = new Clients{ Login = login, Password = password1};
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
