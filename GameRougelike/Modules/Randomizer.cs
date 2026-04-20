using GameRougelike.Modules.Entities;
using ISIP523_Sidorov.Modules.Entities;
using ISIP523_Sidorov.Modules.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GameRougelike.Modules
{
    public static class Randomizer
    {
        static Random random = new Random();
        static List<string> loots = new List<string>() { "зелье", "оружие", "броня" };
        static List<string> Weapon_names_prefix = new List<string> { "Проклятый", "Устрашающий", "Золотой", "Ненасытный", "Святой", "Нечестивый", "Старый" };
        static List<string> Weapon_names = new List<string> { "Меч", "Двуручный меч", "Арбалет", "Лук", "Кинжал", "Боевой топор" };
        static List<string> Weapon_names_suffix = new List<string> { "Лича", "Павшего воина", "Дракона", "Из чешуи дракона", "Из мифрила", "Крестоносца" };
        static List<string> Armor_names = new List<string> { "Доспех мертвеца", "Доспех крестоносца", "Доспех лича", "Латный доспех", "Доспех из чешуи дракона", "Деревянный доспех" };



        public static bool Dodge()
        {
            bool dodge = false;
            if (random.NextDouble() > 1 - 0.4)
            {
                dodge = true;
            }
            return dodge;

        }

        public static bool IsCritOrFreezed(double chance)
        {
            return random.NextDouble() < chance;
        }


        public static string GetRandomLoot (){
            return loots[random.Next(loots.Count)];
        }

        public static Weapon GenerateRandomWeapon()
        {
            int ATK = random.Next(12, 20 + 1);
            string weaponName = Weapon_names_prefix[random.Next(Weapon_names_prefix.Count)] + " ";
            weaponName += Weapon_names[random.Next(Weapon_names.Count)] + " ";
            weaponName += Weapon_names_suffix[random.Next(Weapon_names_suffix.Count)];
            return new Weapon(weaponName,ATK);
        }

        public static Armor GenerateRandomArmor()
        {
            int DEF = random.Next(70, 90 + 1);
            string armorName = Armor_names[random.Next(Armor_names.Count)];
            return new Armor(armorName, DEF);
        }

        public static int GetRandomEnemiesAmount()
        {
            return random.Next(1, 4);
        }

    }
}
