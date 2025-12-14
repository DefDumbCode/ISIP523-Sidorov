using ISIP523_Sidorov.Modules.Enemies;
using ISIP523_Sidorov.Modules.Entities;
using ISIP523_Sidorov.Modules.Equipment;
using ISIP523_Sidorov.Modules.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules
{
    public class Game
    {
        List<string> Weapon_names_prefix = new List<string> { "Проклятый", "Устрашающий", "Золотой", "Ненасытный", "Святой", "Нечестивый", "Старый" };
        List<string> Weapon_names = new List<string> { "Меч", "Двуручный меч", "Арбалет", "Лук", "Кинжал", "Боевой топор" };
        List<string> Weapon_names_suffix = new List<string> { "Лича", "Павшего воина", "Дракона", "Из чешуи дракона", "Из мифрила", "Крестоносца" };
        List<string> Armor_names = new List<string> { "Доспех мертвеца", "Доспех крестоносца", "Доспех лича", "Латный доспех", "Доспех из чешуи дракона", "Деревянный доспех" };

        public enum Race
        {
            Goblin = 1,
            Sekleton,
            Mage
        }

        Random random = new Random();
        public void Start()
        {
            Console.WriteLine("================= D&D: Подземелья и подземелья =================");
            Console.WriteLine("1. Начать игру.\n" +
                    "2. Выход.");
            int input = IntInput();
            input = Choice(input, 2);
            if (input == 1)
            {
                Hero Player = HeroCreate();
                Console.WriteLine();
                int rounds_till_boss = 10;
                bool isboss = false;
                while (Player.HP > 0)
                {
                    rounds_till_boss--;
                    if (rounds_till_boss == 0)
                    {
                        isboss = true;
                        rounds_till_boss = 10;
                    }
                    NextRound(Player, isboss);
                }
            }
        }

        void NextRound(Hero Player, bool isboss)
        {
            int turns = 1;
            if (isboss == false)
            {
                int round = random.Next(0, 2);
                if (round == 0)
                {
                    Console.WriteLine("Вы наткнулись на противника!");
                    var newenemy = NewEnemy.RandomEnemy();
                    Console.WriteLine("Бой!");
                    while (newenemy.HP > 0 && Player.HP > 0)
                    {
                        Console.WriteLine("=== === === ===");
                        Console.WriteLine($"Ход {turns}");
                        turns++;
                        Fight(Player, newenemy);
                        Console.WriteLine("=== === === ===\n");
                    }
                    if (newenemy.HP <= 0)
                    {
                        Console.WriteLine("___ ___ ___ Победа! ___ ___ ___");
                    }
                    else
                    {
                        Console.WriteLine("___ ___ ___ Вы проиграли! ___ ___ ___");
                    }
                }
                else
                {
                    Console.WriteLine("Вы наткнулись на сундук!");
                    Loot(Player);
                }
            }
            else
            {
                Console.WriteLine("Вы наткнулись на Босса!");
                var newboss = NewEnemy.RandomBoss();
                Console.WriteLine("Бой!");
                while (newboss.HP > 0 && Player.HP > 0)
                {
                    Console.WriteLine("=== === === ===");
                    Console.WriteLine($"Ход {turns}");
                    turns++;
                    Fight(Player, newboss);
                    Console.WriteLine("=== === === ===");
                }
            }
        }

        void Fight(Hero Player, Enemy enemy)
        {
            Console.WriteLine();

            enemy.EnemyInfo();
            Console.WriteLine();

            Player.HeroInfo();
            Console.WriteLine();
            Console.WriteLine("Ваш ход:\n" +
                "1. Атаковать.\n" +
                "2. Защищаться.");

            int action = IntInput();
            bool def = false;
            bool dodge = false;
            Choice(action, 2);
            if (action == 1)
            {
                enemy.GetDamage(Player.Weapon.ATK);
            }
            else
            {
                def = true;
                if (random.NextDouble() > 1 - 0.4)
                {
                    dodge = true;
                }
            }

            Console.WriteLine();

            if (enemy.HP > 0)
            {
                Console.WriteLine("Ход противника: ");
                enemy.Attack(Player, def, dodge);
            }
        }

        void Loot(Hero Player)
        {
            Random random = new Random();
            int loot = random.Next(1, 4);
            switch (loot)
            {
                case 1:
                    Console.WriteLine("Вы нашли оружие!");
                    Weapon new_weapon = new Weapon((Weapon_names_prefix[random.Next(0, 7)] + " " + Weapon_names[random.Next(0, 6)] + " " + Weapon_names_suffix[random.Next(0, 6)]), random.Next(10, 21));
                    Player.ChangeWeapon(new_weapon);
                    break;
                case 2:
                    Console.WriteLine("Вы нашли броню!");
                    Armor new_armor = new Armor(Armor_names[random.Next(0, 6)], random.Next(70, 100));
                    Player.ChangeArmor(new_armor);
                    break;
                case 3:
                    Console.WriteLine("Вы нашли зелье лечения!");
                    Player.Heal();
                    break;
            }
        }

        Hero HeroCreate()
        {
            Console.Write("Кто ты, о Странник?\nВы: ");
            string hero_name = Console.ReadLine();
            if (hero_name == null)
            {
                hero_name = "Странник";
                Console.WriteLine("Никак? Значит, будешь просто Странник.");
            }
            Console.WriteLine($"Здравствуй, {hero_name}!");

            Console.WriteLine($"{hero_name}, впереди тебя ждут тяжёлые испытания. Возьми это.");
            Weapon start_weapon = new Weapon("Ржавый меч", 10);
            Armor start_armor = new Armor("Старые доспехи", 70);
            Console.WriteLine("Получено:");
            start_weapon.WeaponInfo();
            start_armor.ArmorInfo();
            Hero Player = new Hero(hero_name, 100, start_weapon, start_armor);
            return Player;
        }

        int Choice(int choice, int max)
        {
            while (choice > max || choice <= 0)
            {
                Console.WriteLine("Нет такого выбора!");
                Console.Write("Выбор: ");
                choice = IntInput();
            }
            return choice;
        }

        int IntInput()
        {
            if (int.TryParse(Console.ReadLine(), out int output))
            {
                return output;
            }
            else
            {
                Console.WriteLine("Нет такого выбора!");
                Console.Write("Выбор: ");
                return IntInput();
            }
        }

    }
}
