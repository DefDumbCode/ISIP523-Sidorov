using ISIP523_Sidorov.Modules.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Entities
{
    public class Hero
    {
        public double HP { get; private set; }
        public Weapon Weapon;
        public Armor Armor;

        public Hero(Weapon weapon, Armor armor)
        {

            HP = 200;
            Weapon = weapon;
            Armor = armor;
        }


        public string GetDamage(double Dmg)
        {
            HP = Math.Round(HP - Dmg);
            return $"Вам нанесли {Math.Round(Dmg)} урона";
        }

        public void Heal()
        {
            HP = 200;
        }
        
        

    }
}
