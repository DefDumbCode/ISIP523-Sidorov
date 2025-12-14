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
            HP *= 2;
            ATK = Math.Round(ATK * 1.5);
            DEF = 1.4;
        }
        
    }
}
