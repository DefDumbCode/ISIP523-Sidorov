using ISIP523_Sidorov.Modules.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Entities
{
    public class Hero
    {
            public string Name { get; private set; }
            public double HP { get; private set; }
            public Weapon Weapon;
            public Armor Armor;

            public Hero(string name, double hp, Weapon weapon, Armor armor)
            {
                Name = name;
                HP = hp;
                Weapon = weapon;
                Armor = armor;
            }

            public void HeroInfo()
            {
                Console.WriteLine($"{Name}:\n" +
                    $"ОЗ: {HP}");
            }

            public void GetDamage(double Dmg)
            {
                Console.WriteLine($"Вам нанесли {Math.Round(Dmg)} урона");
                HP = Math.Round(HP - Dmg);
            }

            public void Heal()
            {
                HP = 100;
            }

            public void ChangeWeapon(Weapon new_weapon)
            {
                Console.WriteLine("Вы нашли:");
                new_weapon.WeaponInfo();
                Console.WriteLine("Ваше оружие:");
                Weapon.WeaponInfo();
                Console.WriteLine("Заменить оружие?\n" +
                    "1. Да.\n" +
                    "2. Нет.");
                string change = Console.ReadLine();
                while (change != "1" && change != "2")
                {
                    Console.WriteLine("Неправильный ввод!");
                    Console.Write("Ввод: ");
                    change = Console.ReadLine();
                }
                if (change == "1")
                {
                    Weapon = new_weapon;
                }
            }

            public void ChangeArmor(Armor new_armor)
            {
                Console.WriteLine("Вы нашли:");
                new_armor.ArmorInfo();
                Console.WriteLine("Ваша броня:");
                Armor.ArmorInfo();
                Console.WriteLine("Заменить броню?\n" +
                    "1. Да.\n" +
                    "2. Нет.");
                string change = Console.ReadLine();
                while (change != "1" && change != "2")
                {
                    Console.WriteLine("Неправильный ввод!");
                    Console.Write("Ввод: ");
                    change = Console.ReadLine();
                }
                if (change == "1")
                {
                    Armor = new_armor;
                }
            }

        

    }
}
