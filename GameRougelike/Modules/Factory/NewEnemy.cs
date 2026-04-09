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
        public static Enemy RandomEnemy()
        {
            Random random = new Random();
            switch (random.Next(1, 5))
            {
                case 1:
                    return new Goblin();
                    break;
                case 2:
                    return new Sekleton();
                    break;
                case 3:
                    return new Mage();
                    break;
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
                    break;
                case 2:
                    return new Arhcimage();
                    break;
                case 3:
                    return new Coval();
                    break;
                case 4:
                    return new Pestov();
                default: return new Pestov();
            }
        }

    }
}
