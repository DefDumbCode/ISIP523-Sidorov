using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRougelike.Modules;

namespace ISIP523_Sidorov.Modules.Enemies
{
    internal class Mage : Enemy
    {
        public double Freeze;
        public Mage()
        {
            MaxHP = 25;
            HP = MaxHP;
            ATK = 15;
            DEF = 2;
            Race = Race.Mage;
            EnemyName = "Маг";
            Freeze = 0.15;
            enemyImg = "https://cdn-icons-png.flaticon.com/512/2210/2210034.png";
        }

        public override string Attack(Hero Player, bool def)
        {
            string output = "";
            if (def == true)
            {
                output += Player.GetDamage(ATK * (Player.Armor.DEF / 100));
            }
            else
            {
                output += Player.GetDamage(ATK);
            }

            if (Randomizer.IsCritOrFreezed(Freeze))
            {
                output += "\nВас заморозили! Вы пропускаете ход.\n";
                output += Attack(Player, true);
            }
            return output;

        }

    }
}
