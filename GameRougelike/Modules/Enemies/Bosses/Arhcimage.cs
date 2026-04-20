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
            EnemyName = "Архимаг C++";
            MaxHP = Math.Round(HP * 1.8);
            HP = MaxHP;
            ATK = Math.Round(ATK * 1.6);
            DEF = Math.Round(DEF * 1.1);
            Freeze = 0.15 + 0.1;
        }
    }
}
