using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies.Bosses
{
    internal class Coval : Sekleton
    {
        public Coval()
        {
            EnemyName = "Ковальски";
            MaxHP = Math.Round(HP * 2.5);
            HP = MaxHP;
            ATK = Math.Round(ATK * 1.3);
            DEF = Math.Round(DEF * 1.4);
        }
        
    }
}
