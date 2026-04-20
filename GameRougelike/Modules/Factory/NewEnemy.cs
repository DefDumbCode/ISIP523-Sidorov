using ISIP523_Sidorov.Modules.Enemies;
using ISIP523_Sidorov.Modules.Enemies.Bosses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP523_Sidorov.Modules.Factory
{
    public static class NewEnemy
    {
        static Random random = new Random();

        public static Enemy RandomEnemy()
        {
            switch (random.Next(1, 5))
            {
                case 1:
                    return new Goblin();
                case 2:
                    return new Sekleton();
                case 3:
                    return new Mage();
                 case 4:
                    return new Slime();
                default: return new Slime();
            }
        }

        public static Enemy RandomBoss()
        {
            Random random = new Random();
            switch (random.Next(1, 5))
            {
                case 1:
                    return new VVG();
                case 2:
                    return new Arhcimage();
                case 3:
                    return new Coval();
                case 4:
                    return new Pestov();
                default: return new Pestov();
            }
        }

    }
}
