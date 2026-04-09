using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Enemies.Bosses
{
    internal class Arhcimage : Mage
    {
        public Arhcimage()
        {
            HP = Math.Round(HP * 1.8);
            ATK = Math.Round(ATK * 1.6);
            DEF = Math.Round(DEF * 1.1);
            Freeze += 10;
        }
    }
}
