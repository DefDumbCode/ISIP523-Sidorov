using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies
{
    internal class Slime : Enemy
    {
        public Slime() 
        {
            HP = 30;
            ATK = 4;
            DEF = 1;
            Race = Game.Race.Slime;
        }

        public override void GetDamage(double Dmg)
        {
            base.GetDamage(Dmg - 2);
        }
    }
}
