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
            HP *= 2;
            ATK = Math.Round(6 * 1.5);
            DEF = 1.2;
            Crit += 10;
        }
    }
}
