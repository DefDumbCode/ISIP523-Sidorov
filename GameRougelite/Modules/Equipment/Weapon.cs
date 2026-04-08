using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Equipment
{
    public class Weapon
    {
        public string Name;
        public int ATK;

        public Weapon(string name, int atk)
        {
            Name = name;
            ATK = atk;
        }

        public Weapon()
        {
            Name = "Ржавый меч";
            ATK = 12;
        }

        public void WeaponInfo()
        {
            Console.WriteLine($"Оружие:\n" +
                $"Название: {Name}\n" +
                $"Урон: {ATK}");
        }
    };
    
}
