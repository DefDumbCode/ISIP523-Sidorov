using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies.Bosses
{
    internal class Pestov : Sekleton
    {
        public double Freeze;
        public Pestov()
        {
            HP = Math.Round(HP * 1.3);
            ATK = Math.Round(ATK * 1.8);
            DEF = Math.Round(DEF * 0.6);
            Freeze = 0.5;
        }

        public override void Attack(Hero Player, bool def, bool dodge)
        {
            Random rand = new Random();
            if (dodge == false)
            {
                Player.GetDamage(ATK);
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
