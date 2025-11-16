using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isip_523_Sidorov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Details> details = new List<Details>();

            Console.WriteLine("1. Начать игру\n" +
                "2. Выход");
            string input = Console.ReadLine();
            while (input != "1" || input != "2")
            {
                Console.WriteLine("Некорректный ввод!");
                Console.Write("Повторный ввод: ");
                input = Console.ReadLine();
            }

            switch (input)
            {
                case "1":
                    //Game();
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


            void Game()
            {

            }

        }
    }
}
