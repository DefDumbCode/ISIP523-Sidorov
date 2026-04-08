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
            HP = 65;
            ATK = 6;
            DEF = 1;
            Race = Game.Race.Goblin;
            Crit = 0.35;
        }

        public override void Attack(Hero Player, bool def, bool dodge)
        {
            Random rand = new Random();
            if (dodge == false)
            {
                if (def == true)
                {
                    if (rand.NextDouble() > 1 - Crit)
                    {
                        Console.WriteLine("Крит!");
                        Player.GetDamage(ATK * 2 * (Player.Armor.DEF / 100));
                    }
                    else
                    {
                        Player.GetDamage(ATK * (Player.Armor.DEF / 100));
                    }
                }
                else
                {
                    if (rand.NextDouble() > 1 - Crit)
                    {
                        Player.GetDamage(ATK * 2);
                    }
                    else
                    {
                        Player.GetDamage(ATK);
                    }
                }
            }
            else
            {
                Console.WriteLine("Вы успешно уклонились от атаки!");
            }
        }
        
    }
}
