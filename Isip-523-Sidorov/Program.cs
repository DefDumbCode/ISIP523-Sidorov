using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Isip_523_Sidorov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Details> details = Core.Context.Details.ToList();
            List<Wherehorse> wharehouses = new List<Wherehorse>();
            Console.WriteLine("1. Начать игру\n" +
                "2. Выход");
            string input = Console.ReadLine();
            while (input != "1" && input != "2")
            {
                Console.WriteLine("Некорректный ввод!");
                Console.Write("Повторный ввод: ");
                input = Console.ReadLine();
            }

            switch (input)
            {
                case "1":
                    Player player = new Player();
                    NewPlayer(out player);
                    //Game(player);
                    break;
                case "2":
                    break;
                default:
                    break;
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

            void Game(Player player)
            {
                List<Wherehorse> players_wharehouse = wharehouses.Where(d => d.PlayerID == player.PlayerID).ToList();
                while (player.Balance >= 0)
                {
                    Car car = new Car();
                    car.NewCar(details);
                    List<Wherehorse> players_detail = new List<Wherehorse>();
                    Console.WriteLine("Сломанные детали");
                    foreach (var item in car.Broken_details)
                    {
                        players_detail.Add(players_wharehouse.First(d => d.DetailID == item.DetailID));
                        foreach (var detail in players_detail)
                        {
                            Console.WriteLine($"{item.DetailName} (У Вас: {detail.Amount})");
                        }
                    }


                    Console.WriteLine("Что делать?\n" +
                        "1. Чинить.\n" +
                        "2. Отказать.\n" +
                        "3. Купить детали.");

                    string action = Console.ReadLine();
                    while (action != "1" && action != "2" && action != "3")
                    {
                        Console.WriteLine("Некорректный ввод!");
                        Console.Write("Повторный ввод: ");
                        action = Console.ReadLine();
                    }

                    switch (action)
                    {
                        case "1":
                            bool can_serve = true;
                            foreach (var item in players_detail)
                            {
                                if (item.Amount == 0)
                                {
                                    can_serve = false;
                                }
                            }

                            if (can_serve == true)
                            {
                                foreach (var item in players_detail)
                                {
                                    players_wharehouse.First(d => d.DetailID == item.DetailID).Amount--;
                                }
                            }
                            else
                            {
                                Console.WriteLine("У Вас не оказалось нужной детали!\n" +
                                    "Клиет недоволен! (-250 зол.)");
                                player.Balance -= 200;
                            }

                            break;
                        case "2":
                            Console.WriteLine("Клиент недоволен! (-200 зол.)");
                            player.Balance -= 200;
                            break;
                        case "3":
                            //BuyDetails();
                            break;
                        default:
                            //BuyDetails();
                            break;
                    }

                }
            }


            void NewPlayer(out Player player)
            {
                player = new Player
                {
                    Balance = 100,
                };

                Random rand = new Random();
                foreach (var item in details)
                {
                    Wherehorse wherehorse = new Wherehorse
                    {
                        DetailID = item.DetailID,
                        PlayerID = player.PlayerID,
                        Amount = rand.Next(1, 5),
                    };
                    wharehouses.Add(wherehorse);

                }
            }
        }

    }
}
