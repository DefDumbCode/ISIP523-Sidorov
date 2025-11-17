using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                    Game(player);
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
                List<Wherehorse> players_wharehouse = Core.Context.Wherehorse.ToList().Where(d => d.PlayerID == player.PlayerID).ToList();
                while (player.Balance >= 0)
                {
                    Car car = new Car();
                    car.NewCar(details);
                    List<Wherehorse> players_detail = new List<Wherehorse>();
                    Console.WriteLine("Сломанные детали");
                    foreach (var item in car.Broken_details)
                    {
                        players_detail.Add(players_wharehouse.First(d => d.DetailID == item.DetailID));
                        Console.WriteLine($"{item.DetailName} (У Вас: {players_detail.Last().Amount})");
                    }

                    string action = WhatToDo();
                    bool client_served = false;
                    while (client_served == false)
                    {
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
                                }
                                client_served = true;
                                break;
                            case "2":
                                Console.WriteLine("Клиент недоволен! (-200 зол.)");
                                client_served = true;
                                break;
                            case "3":
                                BuyDetails(players_wharehouse, player);
                                ShowClient(car, players_detail);
                                action = WhatToDo();
                                break;
                            default:
                                //BuyDetails();
                                break;
                        }
                    }
                }
            }


            void NewPlayer(out Player player)
            {
                player = new Player
                {
                    Balance = 1000,
                };
                Core.Context.Player.Add(player);
                
                Random rand = new Random();
                foreach (var item in details)
                {
                    Wherehorse wherehorse = new Wherehorse
                    {
                        DetailID = item.DetailID,
                        PlayerID = player.PlayerID,
                        Amount = rand.Next(1, 5),
                    };
                    Core.Context.Wherehorse.Add(wherehorse);
                }
                Core.Context.SaveChanges();
            }

            void BuyDetails(List<Wherehorse> players_wharehouse, Player player)
            {
                Console.WriteLine("===МАГАЗИН===");
                foreach(var item in details)
                {
                    Console.WriteLine($"{item.DetailID}: {item.DetailName}. Цена: {item.Price}  (У Вас {players_wharehouse.First(d => d.DetailID == item.DetailID).Amount})");
                }
                Console.WriteLine($"Ваш баланс: {player.Balance}");

                Console.Write("Введите ID деталей, которые хотите заказать: ");
                int shop = IntInput();
                while (details.FirstOrDefault(d => d.DetailID == shop) == null)
                {
                    Console.WriteLine("Детали не найдено!");
                    Console.WriteLine("Попробуйте ещё раз.");
                    shop = IntInput();
                }

                Console.Write("Введите количество: ");
                int buy = IntInput();
                while (buy <= 0)
                {
                    Console.WriteLine("Указано неправильное количество!");
                    Console.WriteLine("Попробуйте ещё раз");
                    buy = IntInput();
                }

                if (details.First(d => d.DetailID == shop).Price * buy <= player.Balance)
                {
                    player.Balance -= details.First(d => d.DetailID == shop).Price * buy;
                    players_wharehouse.First(d => d.DetailID == shop).Amount += buy;
                    Core.Context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("У Вас не хватает денег XD");
                }
            }


            void ShowClient(Car car, List<Wherehorse> players_detail)
            {
                Console.WriteLine("Сломанные детали");
                foreach (var item in car.Broken_details)
                {

                    Console.WriteLine($"{item.DetailName} (У Вас: {players_detail.Last().Amount})");
                }
            }

            string WhatToDo()
            {
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
                return action;
            }
        }

    }
}
