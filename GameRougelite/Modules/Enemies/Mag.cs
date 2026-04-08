using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies
{
    internal class Mage : Enemy
    {
        public double Freeze;

        public Mage()
        {
            HP = 60;
            ATK = 7;
            DEF = 0.8;
            Race = Game.Race.Mage;
            Freeze = 0.4;
        }

        public override void Attack(Hero Player, bool def, bool dodge)
        {
            Random rand = new Random();
            if (dodge == false)
            {
                if (def == true)
                {
                    Player.GetDamage(ATK * (Player.Armor.DEF / 100));
                }
                else
                {
                    Player.GetDamage(ATK);
                }

                if (rand.NextDouble() > 1 - Freeze)
                {
                    Console.WriteLine("Вас заморозили! Вы пропускаете ход.");
                    Attack(Player, true, false);
                }
            }
            else
            {
                Console.WriteLine("Вы успешно уклонились от атаки");
            }
        }

    }
}
