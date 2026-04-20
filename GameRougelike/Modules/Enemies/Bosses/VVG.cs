using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies.Bosses
{
    internal class VVG : Goblin
    {
        public VVG()
        {
            EnemyName = "ВВГ";
            MaxHP = Math.Round(HP * 2);
            HP = MaxHP;
            ATK = Math.Round(ATK * 1.5);
            DEF = Math.Round(DEF * 1.2);
            Crit = 0.3;
        }
    }
}
