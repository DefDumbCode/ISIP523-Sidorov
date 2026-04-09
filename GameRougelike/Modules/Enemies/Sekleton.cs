using ISIP523_Sidorov.Modules.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies
{
    public class Sekleton : Enemy
    {
        public bool IgnoreDEF;

        public Sekleton()
        {
            HP = 50; 
            ATK = 5;
            DEF = 1.2;
            Race = Game.Race.Sekleton;
            IgnoreDEF = true;
        }

        public override void Attack(Hero Player, bool def, bool dodge)
        {
            if (dodge == false)
            {
                Player.GetDamage(ATK);
            }
            else
            {
                Console.WriteLine("Вы успешно уклонились от атаки");
            }
        }
    }
}
