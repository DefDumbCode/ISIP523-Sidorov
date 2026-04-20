using GameRougelike.Modules;
using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies
{
    public class Goblin:Enemy
    {
        public double Crit;
 
        public Goblin()
        {
            MaxHP = 30;
            HP = MaxHP;
            ATK = 12;
            DEF = 3;
            Race = Race.Goblin;
            EnemyName = "Гоблин";
            Crit = 0.20;
            enemyImg = "https://cdn-icons-png.flaticon.com/512/6721/6721392.png";
        }

        public override string Attack(Hero Player, bool def)
        {
            string output = "";
            if (def == true)
            {
                if (Randomizer.IsCritOrFreezed(Crit))
                {
                    output += "Крит!\n";
                    output += Player.GetDamage(ATK * 2 * (Player.Armor.DEF / 100));
                }
                else
                {
                    output += Player.GetDamage(ATK * (Player.Armor.DEF / 100));
                }
            }
            else
            {
                if (Randomizer.IsCritOrFreezed(Crit))
                {
                    output += "Крит!\n";
                    output += Player.GetDamage(ATK * 2);
                }
                else
                {
                    output += Player.GetDamage(ATK);
                }
            }
            return output;
        }        
    }
}
