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
